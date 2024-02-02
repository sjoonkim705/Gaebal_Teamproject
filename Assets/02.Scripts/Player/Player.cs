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

    public int _playerHealth;
    public int PlayerMaxHealth;

    //private int _playerHealth;
    //private int _playerMaxHealth;

    private Rigidbody2D playerRigid;

    public int PlayerLevel;

    private SpriteRenderer _playerSr = null;
    WeaponType WType;
    private const float DEFALT_PLAYER_SPEED = 5.0f;

    public void DecreasePlayerHealth(int amount)
    {
        if (amount <=0 || _playerHealth <=0)
        {
            return;
        }

        _playerHealth -= amount;
    }
    private void Awake()
    {
        scanner = GetComponent<Scanner>();
        playerRigid = GetComponent<Rigidbody2D>();


    }
    void Start()
    {
        PlayerMaxHealth = 100;
        _playerHealth = PlayerMaxHealth;
        PlayerLevel = 0;   // 첫 시작때 경험치, 레벨 0부터 시작
        LevelCount = 0;


        Speed = DEFALT_PLAYER_SPEED;
        _playerSr = GetComponent<SpriteRenderer>(); // playermove 좌우반전을 위한 spriterenderer

    }

    void Update()
    {
        InputVec.x = Input.GetAxis("Horizontal");
        InputVec.y = Input.GetAxis("Vertical");
        int expRequired = (PlayerLevel + 1) * 10;

        if (LevelCount >= expRequired)
        {
            PlayerLevel++;
            LevelCount = 0;
            Debug.Log($"LevelUp : Level = {PlayerLevel}");
        }
        if (_playerHealth <= 0)
        {
            DiePlayer();
        }

    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DecreasePlayerHealth(10);
            //Debug.Log("Health Decreased");
        }
        //enemyCollisionTimer = 0;

    }

    


    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.collider.tag);
        if(other.collider.CompareTag("Enemy"))
        {
            Vector2 dir = other.transform.position - transform.position ;
            dir.Normalize();
            float power = 500f;
            other.collider.GetComponent<Rigidbody2D>().AddForce(dir.normalized * power);
            _playerHealth -= 10;
           // Debug.Log($"PlayerHP {_playerHealth}");
        }

/*        Debug.Log(other.tag);

        if (other.CompareTag("Enemy"))
        {
            enemyCollisionTimer += Time.fixedDeltaTime;
            if (enemyCollisionTimer > 0.2f)
            {
                DecreasePlayerHealth(10);
               // Debug.Log($"{_playerHealth}");
                enemyCollisionTimer = 0;
            }
        }*/
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void DiePlayer()
    {
        /*        _playerSr.flipX = false;
                transform.rotation = UnityEngine.Quaternion.Euler(new Vector3(0, 0, 90));*/
  //      Debug.Log("Player Died");
    }
    private void PlayerMove()
    {


        Vector2 nextPos = InputVec * Speed;
        GetComponent<Rigidbody2D>().velocity = nextPos;


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
