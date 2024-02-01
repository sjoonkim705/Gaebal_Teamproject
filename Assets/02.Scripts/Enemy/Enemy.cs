using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 1번 적 이동
    // 2번 플레이어 팔로우
    // 3번 무기로 죽음


    public float Speed = 1f;
    public int Health = 2;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Bullet") 
        {
            Weapon bellet = collision.collider.GetComponent<Weapon>();

            if(bellet.WType == WeaponType.Kunai) 
            {
                Health -= 1;
            }
            if (Health <= 0) 
            {
                Destroy(collision.collider.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
