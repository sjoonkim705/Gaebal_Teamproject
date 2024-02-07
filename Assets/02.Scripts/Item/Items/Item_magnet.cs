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
    public float magnetRange = 5f; // 마그넷의 범위

    private void Start()
    {
        this.gameObject.SetActive(true);
        Player ply = FindObjectOfType<Player>();
        this.transform.position = ply.transform.position;
        _dir.Normalize();
        float speed = 5f;
        transform.position += (Vector3)_dir * speed * Time.deltaTime;
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

            GameObject[] magnets = GameObject.FindGameObjectsWithTag("Item_Magnet");

            foreach (GameObject magnet in magnets)
            {
                float distanceToMagnet = Vector2.Distance(transform.position, magnet.transform.position);
                if (distanceToMagnet <= magnet.GetComponent<Item_magnet>().magnetRange)
                {
                    // 마그넷으로 끌려가는 로직
                    Vector2 directionToMagnet = (magnet.transform.position - transform.position).normalized;
                    transform.position += (Vector3)(directionToMagnet * Speed) * Time.deltaTime;
                    break; // 하나의 마그넷에만 반응하도록 합니다.
                }
            }
        Player ply = FindObjectOfType<Player>();
        this.transform.position = ply.transform.position;
        _dir.Normalize();
        float speed = 5f;
        transform.position += (Vector3)_dir * speed * Time.deltaTime;
        /*        GameObject _target = GameObject.FindGameObjectWithTag("Player");
                _target.transform.position -= transform.position;*/


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
