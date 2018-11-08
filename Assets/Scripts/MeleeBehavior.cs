using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour {

	private Rigidbody2D bot;
	private GameObject player;

	public float speed = 0.5f;

	void Start () {
		bot = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update(){

	}

	void FixedUpdate () {
		move();
	}

	void move(){

		Vector3 playerDir = player.transform.position - bot.transform.position;
		Vector2 direction = new Vector2(playerDir.x, playerDir.y);
		bot.MovePosition(bot.position + direction * Time.fixedDeltaTime);
	}
}
