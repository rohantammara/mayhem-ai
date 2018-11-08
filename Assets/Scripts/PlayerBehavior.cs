using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	private Rigidbody2D player;
	private bool isDead = false;
	private float hitPoints;	

	public float thrust = 10.0f;

	void Start(){
		player = GetComponent<Rigidbody2D>();
		hitPoints = 100.0f;
	}

	void Update(){
		if(hitPoints == 0.0f){
			isDead = true;
		}
	}

	void FixedUpdate(){
	
		if(isDead == false){
			move(player);
		}

	}

	void onCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Melee"){
			Destroy(col.gameObject);
			hitPoints -= 5.0f;
		}
	}

	void move(Rigidbody2D player){
		if(Input.GetKey(KeyCode.W)){
			player.AddForce(player.transform.up * thrust);
		}
		if(Input.GetKey(KeyCode.A)){
			player.AddForce(-player.transform.right * thrust);
		}
		if(Input.GetKey(KeyCode.S)){
			player.AddForce(-player.transform.up * thrust);
		}
		if(Input.GetKey(KeyCode.D)){
			player.AddForce(player.transform.right * thrust);
		}
	}

}
