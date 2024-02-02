using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
