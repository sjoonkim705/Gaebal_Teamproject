using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 InputVec;
    public Scanner scanner;
    public float Speed;
    public float Health;
    private SpriteRenderer _playerSr = null;
    public GameObject[] EnabledWeapons;

    private const float DEFALT_PLAYER_SPEED = 5.0f;

    private void Awake()
    {
        scanner = GetComponent<Scanner>();

    }
    void Start()
    {
        Speed = DEFALT_PLAYER_SPEED;
        _playerSr = GetComponent<SpriteRenderer>(); // playermove 좌우반전을 위한 spriterenderer
    }

    // Update is called once per frame
    void Update()
    {
        InputVec.x = Input.GetAxis("Horizontal");
        InputVec.y = Input.GetAxis("Vertical");
        PlayerAttack();
 

    }
    private void LateUpdate()
    {
        PlayerMove();

    }
    private void PlayerAttack()
    {
        foreach (GameObject weapon in EnabledWeapons)
        {
            // 각각 쿨타임당 한번씩 호출

           // float coolTime = weapon.coolTime;

           // weapon.cooltime = gmainstantiate
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
