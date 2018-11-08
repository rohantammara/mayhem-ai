using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour {

	Camera camera;

	private Rigidbody2D turret;

	public Transform bulletPrefab;

	void Start () {
		turret = GetComponent<Rigidbody2D>();
		camera = Camera.main;
	
	}
	
	void Update(){
		turret.transform.eulerAngles = new Vector3(0, 0, getCursorDir());
		if(Input.GetMouseButtonDown(0)){
			Instantiate(bulletPrefab, turret.transform.position + turret.transform.up*0.75f, turret.transform.rotation);
		}
	}

	void FixedUpdate () {
	}

	float getCursorDir(){
		Vector3 cursorPos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
		float cursorDir = Vector2.SignedAngle(Vector2.up, new Vector2(cursorPos.x, cursorPos.y) - new Vector2(turret.position.x, turret.position.y));
		return cursorDir;
	}
}
