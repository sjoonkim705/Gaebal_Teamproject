using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public enum EnemyType 
{
    Enemy1,
    Enemy2
}
public class Enemy : MonoBehaviour
{
    // 1번 적 이동
    // 2번 플레이어 팔로우
    // 3번 무기로 죽음

    public EnemyType EType;

    public float Speed = 1f;
    public int Health = 2;

    public GameObject target; // 플레이어를 따라가기 위한 대상 설정
    private Vector2 dir; // 이동 방향 저장

    SpriteRenderer EnemySpriter; // 에너미 컴포넌트

    public GameObject BioFuel_Green;
    public GameObject BioFuel_Blue;
    public GameObject BioFuel_Yellow;

    private Vector3 deathPosition; // 에너미 죽은 위치 저장

    public Animator DieE;
    public bool IsDie = false;

    public GameObject EnemyVFX_BOOMPrefab;
   
    private void OnEnable()
    {
        IsDie = false;
    }

    void Start()
    {
        IsDie = false;
        EnemySpriter = GetComponent<SpriteRenderer>(); // 2번
    }
    void FixedUpdate()
    {
        EnemyMove();


        EnemySpriter.flipX = target.transform.position.x < this.transform.position.x; // 2번

        DieE.SetBool("IsDie", IsDie);
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
        if (Collider.tag == "Bullet") // 태그 확인
        {
            GameObject vfx = Instantiate(EnemyVFX_BOOMPrefab);
            vfx.transform.position = this.transform.position;
            
            
            Kunai_bullet bellet = Collider.GetComponent<Kunai_bullet>();
            // Debug.Log("qwe");

            

            if (bellet.WType == WeaponType.Kunai)
            {
                Health--;
                // Debug.Log($"체력{Health}");
            }
            else if (bellet.WType == WeaponType.Kunai_Upgrade)
            {
                Health--;
            }
            if (Health <= 0)
            {
                IsDie = true;
                Invoke("DieEnemy", 1f);

            }
            Collider.gameObject.SetActive(false);
            
        }
       
    }
    public void DieEnemy() 
    {
        deathPosition = transform.position;

        // Destroy(gameObject);
        gameObject.SetActive(false);
        MakeBioFuel();
    }
    public void MakeBioFuel()
    {
        int makebio = Random.Range(0, 10);
        Debug.Log(makebio);

        if (EType == EnemyType.Enemy1)
        {
            if (makebio <= 7)
            {
                GameObject biofuel = Instantiate(BioFuel_Green);

                biofuel.transform.position = deathPosition;
            }
            else
            {
                GameObject biofuel = Instantiate(BioFuel_Blue);

                biofuel.transform.position = deathPosition;
            }
        }
        else if (EType == EnemyType.Enemy2) 
        {
            if (makebio <= 6)
            {
                GameObject biofuel = Instantiate(BioFuel_Blue);

                biofuel.transform.position = deathPosition;
            }
            else 
            {
                GameObject biofuel = Instantiate(BioFuel_Yellow);

                biofuel.transform.position = deathPosition;
            }
        }
    }
}
