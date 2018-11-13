using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpBulletBehavior : MonoBehaviour {

    private Rigidbody2D spbullet;

    public float thrust = 0.008f;



    void Start()
    {

        spbullet = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        spbullet.AddForce(spbullet.transform.up * thrust);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "SpBullet")
            Destroy(gameObject);

    }
}
