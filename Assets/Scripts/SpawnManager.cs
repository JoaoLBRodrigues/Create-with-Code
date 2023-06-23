using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Vector3 spwanPos= new Vector3(25,0,0);
    private float StartDelay=2;
    private float repeatRate=2;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnObstacle",StartDelay, repeatRate);
        playerControllerScript=GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void SpawnObstacle(){
        if(playerControllerScript.gameOver==false){
         Instantiate(obstaclePrefab, spwanPos, obstaclePrefab.transform.rotation);
        }
    }
}
