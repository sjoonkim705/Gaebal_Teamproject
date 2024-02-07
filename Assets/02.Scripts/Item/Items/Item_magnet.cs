using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item_BioFuel;

public class Item_magnet : MonoBehaviour
{
    public float Speed = 10f;
    public GameObject bioFuel;
    Vector2 _dir;
    private GameObject _target;


    private void Start()
    {

    }

    private void Update()
    {
        
        /**
        // 1. 플레이어를 찾고
        GameObject _target = GameObject.Find("BioFuel");
        Debug.Log("마그넷을 찾음");
        // 2. 방향을 정하고
        // _target.transform.position += Vector3.left;
        _target.transform.position -= transform.position;
        _dir.Normalize();
        // _dir = MagnetPosition.transform.position - transform.position;
        // _dir.Normalize();
        Debug.Log("마그넷 방향");
        // 3. 스피드에 맞게 이동
        //  transform.position += MP * Speed * Time.deltaTime;
        // Vector2 newPosition = transform.position + (Vector3)(_dir * Speed) * Time.deltaTime;
        //  transform.position = newPosition;
        Debug.Log("마그넷으로 이동");
        **/

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BioFuel"))
        {
            /**
            // Debug.Log($"test");

            // BioFuel에 부착된 Player 컴포넌트 가져오기
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                // 플레이어의 LevelCount 증가
             //   player.LevelCount += 1;
              //  Debug.Log($"플레이어 레벨 업! 현재 레벨: {player.LevelCount}");
            }
            else
            {
               // Debug.LogError("BioFuel에 Player 컴포넌트가 없습니다.");
            }
            **/
            collision.gameObject.SetActive(false);
        }
    }
}
