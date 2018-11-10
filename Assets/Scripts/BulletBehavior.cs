using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	private Rigidbody2D bullet;

	public float thrust = 0.008f;

	void Start () {

		bullet = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		
		bullet.AddForce(bullet.transform.up * thrust);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag != "Bullet")
			Destroy(gameObject);
	}
}
