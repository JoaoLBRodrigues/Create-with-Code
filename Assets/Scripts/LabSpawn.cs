using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabSpawn : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject Powerup1;

    private float zEnemySpawn=12.0f;
    private float xSpawnRange=16.0f;
    private float zPowerupRange=5.0f;
    private float ySpawn=1.0f;

    private float powerupSpawnTime =5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",startDelay,enemySpawnTime);
        InvokeRepeating("SpawnPowerup",startDelay,powerupSpawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy(){
        float randomX=Random.Range(-xSpawnRange,xSpawnRange);
        int randomIndex=Random.Range(0,enemies.Length);

        Vector3 spawnPos =new Vector3(randomX,ySpawn,zEnemySpawn);

        Instantiate(enemies[randomIndex],spawnPos,enemies[randomIndex].gameObject.transform.rotation);

    }

    void SpawnPowerup(){
        float randomX=Random.Range(-xSpawnRange,xSpawnRange);
        float randomZ=Random.Range(-zPowerupRange,zPowerupRange);

        Vector3 spawnPos =new Vector3(randomX,ySpawn,randomZ);

        Instantiate(Powerup1,spawnPos,Powerup1.gameObject.transform.rotation);

    }
}
