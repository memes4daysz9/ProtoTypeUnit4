using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange= 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);//spawn powerup every round

        
    }

    void SpawnEnemyWave(int enemiesToSpawn){//spawns enemies every round
        for (int i = 0; i < enemiesToSpawn; i++){
        Instantiate(enemyPrefab,GenerateSpawnPosition(),enemyPrefab.transform.rotation);
        }
    }

    
    private Vector3 GenerateSpawnPosition(){//spawns things at a random point
        float SpawnPosX = Random.Range(-spawnRange,spawnRange);
        float SpawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos = new Vector3(SpawnPosX, 0, SpawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0){
            waveNumber++; //wave boi
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab,GenerateSpawnPosition(), powerupPrefab.transform.rotation); 
        }
    }
}
