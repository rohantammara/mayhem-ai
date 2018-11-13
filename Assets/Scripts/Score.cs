using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text scoreText;
	private PlayerBehavior playerScript;
	
	void Awake(){
		scoreText = GetComponent<Text>();
		
		GameObject player;
		player = GameObject.Find("Player");
		playerScript = player.GetComponent<PlayerBehavior>();
	}		
	
	void Update() {
		scoreText.text = "Score :" + playerScript.score;
	}
}
