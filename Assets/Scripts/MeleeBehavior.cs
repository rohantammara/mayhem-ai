using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour {

	private Rigidbody2D bot;
	private GameObject player;
	private float hitPoints = 100.0f;
	
	public float speedInverse = 5.0f;

	void Start () {
		
		bot = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update(){

		if(hitPoints == 0.0f){
			Destroy(gameObject);
		}
	}

	void FixedUpdate () {
		if(player != null)
			moveBot();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Bullet"){
			hitPoints -= 50.0f;
		}
	}

	void moveBot(){

		Vector3 playerDir = player.transform.position - bot.transform.position;
		Vector2 direction = new Vector2(playerDir.x, playerDir.y);
		float rotateBy = Vector2.SignedAngle(Vector2.up, direction);
		bot.transform.eulerAngles = new Vector3(0, 0, rotateBy);
		bot.MovePosition(bot.position + direction * Time.fixedDeltaTime/speedInverse);
	}

	float getMovementCost(Rigidbody2D bot){
		return 0;
	}
}
