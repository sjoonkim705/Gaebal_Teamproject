using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 InputVec;
    public Scanner scanner;
    public float Speed;
    public float LevelCount;
    public float expRequired;

    public bool IsShieldOn;
    public int SpeedUpCount;
    public int PlayerHealth;
    public int PlayerMaxHealth;

    public List<Weapon> Weapons;

    private Rigidbody2D playerRigid;

    public int PlayerLevel;

    public Item_UI itemUI;
    private SpriteRenderer _playerSr = null;
    WeaponType WType;
    private const float DEFALT_PLAYER_SPEED = 5.0f;
    public Animator PlayerAnimator;

    Vector2 _dir;

    public void IncreaseSpeed()
    {
        SpeedUpCount++;
        Debug.Log("Speed UP");
        Speed *= 1.1f;
    }
    public void DecreasePlayerHealth(int amount)
    {
        if (amount <=0 || PlayerHealth <=0)
        {
            return;
        }

        PlayerHealth -= amount;
    }
    private void Awake()
    {
        SpeedUpCount = 0;
        scanner = GetComponent<Scanner>();
        playerRigid = GetComponent<Rigidbody2D>();
        PlayerMaxHealth = 100;
        PlayerHealth = PlayerMaxHealth;

    }
    void Start()
    {

        PlayerLevel = 0;   // 첫 시작때 경험치, 레벨 0부터 시작
        LevelCount = 0;


        Speed = DEFALT_PLAYER_SPEED;
        _playerSr = GetComponent<SpriteRenderer>(); // playermove 좌우반전을 위한 spriterenderer
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        InputVec.x = Input.GetAxis("Horizontal");
        InputVec.y = Input.GetAxis("Vertical");
        expRequired = (PlayerLevel + 1) * 10;

        

        if (LevelCount >= expRequired)
        {
            PlayerLevel++;
            LevelCount = 0;
            Debug.Log($"LevelUp : Level = {PlayerLevel}");

            itemUI.Show();

/*            RandomItemSpawner randomItemSpawner = gameObject.AddComponent<RandomItemSpawner>(); 
            randomItemSpawner.SpawnRandomItems();
            Debug.Log("random");*/
            // itemUI.Hide();
        }
        if (PlayerHealth <= 0)
        {
            DiePlayer();
        }

        bool isMoving = playerRigid.velocity.magnitude > 0.1f;
        PlayerAnimator.SetBool("IsMoving", isMoving);
        //PlayerAnimator.SetFloat("MoveY", InputVec.y);



    }
    private void FixedUpdate()
    {
        PlayerMove();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.CompareTag("Enemy"))
        {
            Vector2 dir = other.transform.position - transform.position;
            dir.Normalize();
            float power = 500f;
            other.collider.GetComponent<Rigidbody2D>().AddForce(dir.normalized * power); //적 밀어냄
            PlayerHealth -= 1;
            PlayerAnimator.Play("PlayerHit");
            Debug.Log($"PlayerHP {PlayerHealth}");
        }
    }

    private void DiePlayer()
    {
        /*        _playerSr.flipX = false;
                transform.rotation = UnityEngine.Quaternion.Euler(new Vector3(0, 0, 90));*/
       Debug.Log("Player Died");
    }
    private void PlayerMove()
    {


        Vector2 nextPos = InputVec * Speed;
        playerRigid.velocity = nextPos;


        if (InputVec.x < 0)
        {
           _playerSr.flipX = true;
        }
        else if (InputVec.x > 0)
        {
            _playerSr.flipX = false;
        }

    }



}
