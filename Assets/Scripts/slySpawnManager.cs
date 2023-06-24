using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject PowerPrefab;
    private float spawnRange=9.0f;
    public int enemyCount;
    public int waveNumber=1;
    // Start is called before the first frame update
    void Start()
    {
       SpawnEnemyWave(waveNumber);
        Instantiate(PowerPrefab, Generate(), PowerPrefab.transform.rotation);
        
    }

      void Update()
    {
      enemyCount=FindObjectsOfType<enemy>().Length;
        if(enemyCount ==0)
        {
           waveNumber++;
           SpawnEnemyWave(waveNumber);
           Instantiate(PowerPrefab, Generate(), PowerPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemyToSpwan)
    {  for (int i =0; i < enemyToSpwan; i++)
        {
        Instantiate(enemyPrefab, Generate(), enemyPrefab.transform.rotation);
        }
        
    }


    
    private Vector3 Generate()
    {
    float spawnPosX=Random.Range(-spawnRange,spawnRange);
    float spawnPosZ=Random.Range(-spawnRange,spawnRange);
    Vector3 randomPos=new Vector3(spawnPosX,0,spawnPosZ);
    return randomPos;
    }
}
