using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	private Rigidbody2D player;
	private bool isDead = false;

    public bool sptoggle = false;
	public float hitPoints;
	public float score = 0.0f;
	public float thrust = 10.0f;
    public float sptime = 10f;
    public float count = 0f;

	void Start(){
		player = GetComponent<Rigidbody2D>();
		hitPoints = 100.0f;
	}

	void Update(){

		if(isDead == false && hitPoints == 0.0f){
			isDead = true;
			Destroy(gameObject);
		}

        count = count + (Time.deltaTime * 1);

            if(count > 10)
        {
            sptoggle = false;
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
			hitPoints -= 25.0f;
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "HPickup")
        {
            Destroy(col.gameObject);
            hitPoints = 100.0f;
        }

        if (col.gameObject.tag == "SpPickup")
        {
            Destroy(col.gameObject);
            sptoggle = true;
            count = 0;
            
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
