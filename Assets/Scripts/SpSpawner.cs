using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpSpawner : MonoBehaviour {

    public Transform specialpickupPrefab;
    private PlayerBehavior playerScript;
    private float timer = 30f;

    void Awake()
    {

        GameObject player;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerBehavior>();
    }

    void Start()
    {

        for (int i = 0; i < 1; i++)
        {
            Instantiate(specialpickupPrefab, new Vector3(Random.Range(-7.25f, 7.25f), Random.Range(-2.75f, 2.75f), 0), Quaternion.identity);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = 0; i < 1; i++)
            {

                Instantiate(specialpickupPrefab, new Vector3(Random.Range(-7.25f, 7.25f), Random.Range(-2.75f, 2.75f), 0), Quaternion.identity);
                timer = 30f;
            }
        }
    }
}
