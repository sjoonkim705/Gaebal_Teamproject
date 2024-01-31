using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.Mathematics;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.Instance.player.InputVec;
        float dirX = 0;
        float dirY = 0;

        if (playerDir.x < 0)
        {
            dirX = -1;
        }    
        else
        {
            dirX = 1;
        }

        if (playerDir.y < 0)
        {
            dirY = -1;
        }
        else
        {
            dirY = 1;
        }

        switch (transform.tag)  //player.area가 벗어난 곳이 ground일때만 맵 이동
        {
            case "Ground":
                if(Mathf.Abs(diffX - diffY) <= 0.1f)                // 매우 짧은 간격 차이 상하/좌우 이동이 동시에 일어날 시 한 가지 이동만 일어남 bug발생 수정
                {                                                   // 
                    transform.Translate(Vector3.up * dirY * 40);
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                break;
        }


        




    }
}
