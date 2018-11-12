using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	private Rigidbody2D player;
	private bool isDead = false;
	private float hitPoints;	

	public float thrust = 30.0f;

	void Start(){
		player = GetComponent<Rigidbody2D>();
		hitPoints = 100.0f;
	}

	void Update(){

		if(isDead == false && hitPoints == 0.0f){
			isDead = true;
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
	
		if(isDead == false){
			movePlayer(player);
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Melee"){
			Destroy(col.gameObject);
			hitPoints -= 5.0f;
		}
	}

	void movePlayer(Rigidbody2D player){
		
		Vector2 inDir = new Vector2(0, 0);
		
		if(Input.GetKey(KeyCode.W)){
			inDir = player.transform.up * thrust;
		}
		if(Input.GetKey(KeyCode.A)){
			inDir = -player.transform.right * thrust;
		}
		if(Input.GetKey(KeyCode.S)){
			inDir = -player.transform.up * thrust;
		}
		if(Input.GetKey(KeyCode.D)){
			inDir = player.transform.right * thrust;
		}

		player.AddForce(inDir);
		player.MoveRotation(player.rotation + Vector2.SignedAngle(Vector2.up, player.velocity));
	}

}
