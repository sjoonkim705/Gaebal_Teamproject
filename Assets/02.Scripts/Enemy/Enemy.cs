using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 1번 적 이동
    // 2번 플레이어 팔로우
    // 3번 무기로 죽음


    public float Speed;
    public int Health;

    public GameObject target;
    private Vector2 dir;

    SpriteRenderer EnemySpriter;

    void Start()
    {
        EnemySpriter = GetComponent<SpriteRenderer>(); // 2번
    }

    
    void Update()
    {
        EnemyMove();
    }
    void EnemyMove() // 1번
    {
        target = GameObject.Find("Player");

        dir = target.transform.position - this.transform.position;
        dir = dir.normalized;

        transform.position += (Vector3)(dir * Speed) * Time.deltaTime;
    }

    void LateUpdate() // 2번
    {
        EnemySpriter.flipX = target.transform.position.x > this.transform.position.x;
    }
}