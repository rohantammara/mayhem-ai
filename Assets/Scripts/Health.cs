using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	private Text healthText;
	private PlayerBehavior playerScript;
	
	void Awake(){
		healthText = GetComponent<Text>();
		
		GameObject player;
		player = GameObject.Find("Player");
		playerScript = player.GetComponent<PlayerBehavior>();
	}		
	  
	void Update() {
		healthText.text = "Health :" + playerScript.hitPoints;
	}
}
