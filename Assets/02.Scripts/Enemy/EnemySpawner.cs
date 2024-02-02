using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float _timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(); // 중간에 s 확인 잘하기
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 0.2f) 
        {
            Spawn();
            _timer = 0;
        }
    }
    void Spawn() 
    {
        GameObject enemy = GameManager.Instance.pool.Get(Random.Range(0, 1));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
