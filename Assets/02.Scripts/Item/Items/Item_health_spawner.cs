using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_health_spawner : MonoBehaviour
{
    public float SpawnTime = 1.2f;
    public float CurrentTimer = 0;
    public float MinTime = 0.1f;
    public float MaxTime = 10.0f;

    public GameObject Health;
    private void Start()
    {
        // 시작할 때 적 생성 시간을 랜덤하게 설정한다
        SetRendomTime();
        SetRandomPosition();
    }
    private void SetRendomTime()
    {
        SpawnTime = Random.Range(MinTime, MaxTime);
    }

    private void SetRandomPosition()
    {
        GameObject bomb = Instantiate(Health);
        bomb.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
        bomb.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimer += Time.deltaTime;
        if (CurrentTimer >= SpawnTime)
        {
            // 타이머 초기화
            CurrentTimer = 0f;

            SetRendomTime();
            SetRandomPosition();
        }
    }
}
