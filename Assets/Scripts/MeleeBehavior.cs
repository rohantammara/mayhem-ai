using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour {

	private Rigidbody2D bot;
	private GameObject player;
	private float hitPoints = 100.0f;
	private PlayerBehavior playerScript;
	
	public float speedInverse = 4.5f;

	void Start () {
		
		bot = GetComponent<Rigidbody2D>();
		player = GameObject.Find("Player");
		playerScript = player.GetComponent<PlayerBehavior>();
	}
	
	void Update(){

		if(hitPoints == 0.0f){
			playerScript.score += 1.0f;
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

        if (col.gameObject.tag == "SpBullet")
        {
            hitPoints -= 100.0f;
        }

    }

	void moveBot(){

		Vector2 playerDir = player.transform.position - bot.transform.position;
		float rotateBy = Vector2.SignedAngle(Vector2.up, playerDir);
		bot.transform.eulerAngles = new Vector3(0, 0, rotateBy);

		Vector2 direction = getAStarDir();
		bot.MovePosition(bot.position + direction * Time.fixedDeltaTime/speedInverse);
	}

	Vector2 getAStarDir(){
		
		Vector2 playerDir = player.transform.position - bot.transform.position;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(bot.transform.position, playerDir.magnitude);
		float xSum = 0.0f;
		float ySum = 0.0f;
		for(int i=0; i < colliders.Length; i++){
			Rigidbody2D thing = colliders[i].attachedRigidbody;
			if(thing.tag != "Player" && thing.tag != "Bullet"){
				xSum += thing.transform.position.x - bot.transform.position.x;
				ySum += thing.transform.position.y - bot.transform.position.y;
			}
		}
		Vector2 avoidanceDir = new Vector2(xSum, ySum);
		Vector2 direction = (-avoidanceDir + 3*playerDir);
		return direction;
	}
}