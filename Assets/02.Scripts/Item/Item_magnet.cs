using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_magnet : MonoBehaviour
{
    public float Speed = 10f;
    public GameObject bioFuel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log($"Alpha1 키 입력 감지");
        }

        // 플레이어를 따라오게끔 업데이트
        FollowPlayer();
    }


    private void FollowPlayer()
    {
  
                GameObject playerObject = GameObject.Find("Player");
                if (playerObject != null)
                {
                    Vector3 pos = playerObject.transform.position;
                    Vector3 follow = new Vector3(pos.x, pos.y + 1f, pos.z);

                    // 플레이어 방향으로 이동
                    Vector3 playerDirection = (follow - transform.position).normalized;
                    transform.position += playerDirection * Speed * Time.deltaTime;
                }
                else
                {
                    Debug.LogWarning("플레이어를 찾을 수 없음");
                }
    }
}
