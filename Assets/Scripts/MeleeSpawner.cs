using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : MonoBehaviour {

	public Transform meleePrefab;

	void Start () {

		for(int i=0; i<3; i++){
			Instantiate(meleePrefab, new Vector3(Random.Range(-7.25f, 7.25f), Random.Range(-2.75f, 2.75f), 0), Quaternion.identity);
		}
	}
	
	void FixedUpdate () {

		//if(GameObject.FindGameObjectsWithTag("Melee").Length < 3 || Time.time % 10.0f == 0){
		//	Instantiate(meleePrefab, new Vector3(Random.Range(-7.25f, 7.25f), Random.Range(-2.75f, 2.75f), 0), Quaternion.identity);
		//}
	}
}
