using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item_shoes : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        ShoesSpeed();
    }

    public void ShoesSpeed()
    {
        Player player = GetComponent<Player>();
        player.Speed *= 1.1f;
        float maxSpeed = 10.0f; // 최대 이동 속도 설정
        player.Speed = Mathf.Min(player.Speed, maxSpeed);
    }
}
