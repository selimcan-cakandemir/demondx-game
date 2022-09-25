using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy Instance;
    public GameObject enemy;
    public Transform[] spawn;
    public float waveDuration;
    public int enemyCount;
    private float spawnInterval;
    private float spawnTimer;
    private int enemyNumber = 0;
    
    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
    }

    void Start()
    {
        SetSpawnInterval();
    }

    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if (enemyNumber < enemyCount)
            {
                int rsp = Random.Range(0, spawn.Length);
                Instantiate(enemy, spawn[rsp].position, Quaternion.identity);
                enemyNumber++;
                spawnTimer = spawnInterval;
            }
            else
            {
                //increase enemy count
                //start next wave
                Debug.Log("WAVE OVER");
                
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
        }
    }
    
    void SetSpawnInterval()
    {
        spawnInterval = waveDuration / enemyCount;
    }

    
}
