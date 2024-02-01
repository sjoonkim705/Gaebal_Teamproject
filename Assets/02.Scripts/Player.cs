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
    private int _playerHealth;
    public int PlayerMaxHealth;

    public int PlayerLevel;

    private SpriteRenderer _playerSr = null;
    WeaponType WType;
    private const float DEFALT_PLAYER_SPEED = 5.0f;

    public void DecreasePlayerHealth(int amount)
    {
        if (amount <=0)
        {
            return;
        }

        _playerHealth -= amount;
    }
    private void Awake()
    {
        scanner = GetComponent<Scanner>();


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
        }

    }
    private void LateUpdate()
    {
        PlayerMove();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            DecreasePlayerHealth(10);
            Debug.Log("Health Decreased");
        }
    }

    private void PlayerMove()
    {
        Vector2 nextPos = InputVec * Speed * Time.deltaTime;
        transform.position += (Vector3)nextPos;
        if (InputVec.x < 0)
        {
           _playerSr.flipX = true;
        }
        else
        {
            _playerSr.flipX = false;
        }

    }
}
