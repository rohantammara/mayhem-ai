using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{

    public Transform healthpickupPrefab;
    private PlayerBehavior playerScript;

      void Awake()
        {
           
            GameObject player;
            player = GameObject.Find("Player");
            playerScript = player.GetComponent<PlayerBehavior>();
        }
   
    void Start()
    {

        for (int i = 0; i < 2; i++)
        {
            Instantiate(healthpickupPrefab, new Vector3(Random.Range(-7.25f, 7.25f), Random.Range(-2.75f, 2.75f), 0), Quaternion.identity);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("HPickup").Length < 1 && playerScript.hitPoints <= 50.0f)
        {
            for (int i = 0; i < 2; i++)
            {


                Instantiate(healthpickupPrefab, new Vector3(Random.Range(-7.25f, 7.25f), Random.Range(-2.75f, 2.75f), 0), Quaternion.identity);
            }
        }
    }
}
