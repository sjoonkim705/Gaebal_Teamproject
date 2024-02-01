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

        // 타이머가 0이하로 떨어지면
        if (Timer < 0) 
        {
            // 일정 확률로 적을 생성
            RandomRate();
            // 다시 타이머 랜덤 설정
            RandomSpawnTime();
        }
    }
    void RandomSpawnTime() 
    {
        Timer = Random.Range(MinTime, MaxTime);
    }



    // 적 생성 확률 결정, 일정 확률 이하일 때 적 생성
    void RandomRate() 
    {
        GameObject enemy;

        // 랜덤한 값 생성 -> _enemyrate에 저장
        _enemyrate = Random.Range(0, 100);

        // 랜덤 값 70 이하일 경우
        if (_enemyrate <= 70) 
        {
            // 프리펩 가져옴
            enemy = Instantiate(EnemyPrefab);

            // 적 생성 위치 = EnemySpawn 위치
            enemy.transform.position = EnemySpawn.transform.position;
        }
    }
    


    // "Enemy" 태그를 가진 모든 활성화된 적을 비활성화
    void DeactivateEnemy() 
    {
        // "Enemy" 태그를 가진 모든 게임 오브젝트 찾아 배열로 가져옴
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 배열에 포함된 모든 적에 대해 반복
        foreach(GameObject enemy in enemies) 
        {
            // 적이 현재 활성화되어 있는지 확인
            if (enemy.activeSelf) 
            {
                // 적을 비활성화
                enemy.SetActive(false);
            }
        }
    }



    IEnumerator SpawnEnemies() 
    {
        // 10초 동안 적 생성
        // 적 생성 확률을 결정
        RandomRate();
        // 일정 시간(SpawnInterval) 동안 대기
        yield return new WaitForSeconds(SpawnInterval);


        // 3초 동안 적 비활성화
        // 생성된 적을 비활성화
        DeactivateEnemy();
        // 일정 시간(InactiveInterval) 동안 대기
        yield return new WaitForSeconds(InactiveInterval);
    }
}
