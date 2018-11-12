using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : MonoBehaviour {

	public Transform meleePrefab;

	void Start () {

		for(int i=0; i<5; i++){
			Instantiate(meleePrefab, new Vector3(Random.Range(-36.25f, 36.25f), Random.Range(-13.75f, 13.75f), 0), Quaternion.identity);
		}
	}
	
	void FixedUpdate () {

		if(GameObject.FindGameObjectsWithTag("Melee").Length < 5 || Time.time % 2.0f == 0){
			Instantiate(meleePrefab, new Vector3(Random.Range(-36.25f, 36.25f), Random.Range(-13.75f, 13.75f), 0), Quaternion.identity);
		}
	}
}
