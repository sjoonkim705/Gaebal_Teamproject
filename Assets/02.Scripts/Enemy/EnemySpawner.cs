using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class EnemySpawner : MonoBehaviour
{
    // 에너미 리스폰 될 위치 담은 배열
    public Transform[] spawnPoint;
    // 에너미 리스폰 간격 제어 타이머
    float _timer;
    
    // 경과 시간 측정
    public float timeElapsed;
    // 초기 에너미 리스폰 간격
    float initalSpawnInterval = 1f;
    // 현재 에너미 리스폰 간격
    float currentSpawnInterval;
    // 증가시킬 에너미 리스폰 간격
    float doubleSpawnInterval = 0.2f;
    // 증가시킨 에너미 리스포 기간
    float doublingDuration = 10f;

    EnemySpawnUI uiani;
    

    private void Awake()
    {
        // 자식 오브젝트 중에 있는 모든 Transform 가져와서 배열에 저장
        spawnPoint = GetComponentsInChildren<Transform>(); // 중간에 s 확인 잘하기

        // 초기 에너미 리스폰 간격 설정
        currentSpawnInterval = initalSpawnInterval;

        uiani = FindObjectOfType<EnemySpawnUI>();
       
        
        
    }
    private void Update()
    {
        // 타이머 업데이트
        _timer += Time.deltaTime;
        // 경과 시간 업데이트
        timeElapsed += Time.deltaTime;

        // 일정 간격마다
        if (_timer > currentSpawnInterval) 
        {
            // Spawn 메서드 호출
            Spawn();
            // 타이머 초기화
            _timer = 0;
        }

        if (timeElapsed >= 3f) 
        {
            uiani.SpriteON();
            uiani.ShowUI();
        }
        // 60초가 지나면
        if (timeElapsed >= 6f)
        {
            uiani.SpriteOFF();
            uiani.HideUI();
            // 에너미 리스폰 간격 2배
            currentSpawnInterval = doubleSpawnInterval;
        }
        
        // 30초 이후에는
        if (timeElapsed >= 90f) 
        {
            // 다시 초기 간격으로 변경
            currentSpawnInterval = initalSpawnInterval;

            timeElapsed = 0f;
        }
    }
    // 에너미 리스폰 메서드
    void Spawn() 
    {
        // 게임 매니저에서 오브젝트 풀에서 에너미를 가져와 생성
        GameObject enemy = GameManager.Instance.pool.Get(Random.Range(0, 2));
        // 랜덤한 위치에 에너미 배치
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
