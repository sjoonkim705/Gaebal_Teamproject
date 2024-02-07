using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item_shoes : MonoBehaviour
{

    private void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        ShoesSpeed();
    }

    public void ShoesSpeed()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            Player player = playerObj.GetComponent<Player>();
            if (player != null)
            {
                player.Speed += 10f;
                float maxSpeed = 10.0f; // 최대 이동 속도 설정
                player.Speed = Mathf.Min(player.Speed, maxSpeed);
            }
            else
            {
                Debug.LogError("Player component not found on the object with Player tag.");
            }
        }
        else
        {
            Debug.LogError("Player object not found.");
        }
    }
}
