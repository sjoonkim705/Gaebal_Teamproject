using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject EnemySpawn;

    public float Timer = 3f;
    float _enemyrate;

    public float MinTime = 0.5f;
    public float MaxTime = 1.5f;

    void Start()
    {
        RandomRate();
    }

    
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer < 0) 
        {
            RandomRate();
            RandomSpawnTime();
        }
    }
    void RandomSpawnTime() 
    {
        Timer = Random.Range(MinTime, MaxTime);
    }
    void RandomRate() 
    {
        

        GameObject enemy;

        _enemyrate = Random.Range(0, 100);

        if (_enemyrate <= 70) 
        {
            enemy = Instantiate(EnemyPrefab);

            enemy.transform.position = EnemySpawn.transform.position;
        }
        

    }
}
