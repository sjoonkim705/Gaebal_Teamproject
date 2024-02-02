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

    public float SpawnInterval = 10f;
    public float InactiveInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
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
    void DeactivateEnemy() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies) 
        {
            if (enemy.activeSelf) 
            {
            enemy.SetActive(false);
            }
        }
    }
    IEnumerator SpawnEnemies() 
    {
        // 10초 동안 적 생성
        RandomRate();
        yield return new WaitForSeconds(SpawnInterval);


        // 3초 동안 적 비활성화
        DeactivateEnemy();
        yield return new WaitForSeconds(InactiveInterval);
    }

   
}
