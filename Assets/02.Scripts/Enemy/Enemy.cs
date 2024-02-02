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

    public GameObject BioFuel_Green;
    public GameObject BioFuel_Blue;
    public GameObject BioFuel_Yellow;



    void Start()
    {
        EnemySpriter = GetComponent<SpriteRenderer>(); // 2번
    }


    void FixedUpdate()
    {
        EnemyMove();

        EnemySpriter.flipX = target.transform.position.x > this.transform.position.x; // 2번
    }
    void EnemyMove() // 1번
    {
        target = GameObject.Find("Player");

        dir = target.transform.position - this.transform.position;
        dir = dir.normalized;

        GetComponent<Rigidbody2D>().velocity = dir * Speed;
        //transform.position += (Vector3)(dir * Speed) * Time.deltaTime;


        // GetComponent<Rigidbody2D>().velocity = dir * Speed;
        // transform.position += (Vector3)(dir * Speed) * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D Collider)
    {

        if (Collider.tag == "Bullet")
        {
            Kunai_bullet bellet = Collider.GetComponent<Kunai_bullet>();

            // Debug.Log("qwe");

            if (bellet.WType == WeaponType.Kunai)
            {
                Health -= 1;
                // Debug.Log($"체력{Health}");
            }
            if (Health <= 0)
            {

                // Destroy(gameObject);
                MakeBioFuel();
            }
            Destroy(Collider.gameObject);
        }
        
    }
    public void MakeBioFuel()
    {
        int makebio = Random.Range(0, 10);
        Debug.Log(makebio);

        if (makebio <= 6)
        {
            GameObject biofuel = Instantiate(BioFuel_Green);

            biofuel.transform.position = this.transform.position;
        }
        else if (makebio <= 8)
        {
            GameObject biofuel = Instantiate(BioFuel_Blue);

            biofuel.transform.position = this.transform.position;
        }
        else
        {
            GameObject biofuel = Instantiate(BioFuel_Yellow);

            biofuel.transform.position = this.transform.position;
        }
    }
   
}
