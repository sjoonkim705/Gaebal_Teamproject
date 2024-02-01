using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BioFuel : MonoBehaviour
{
    public enum BioType // 바이오 연료 타입    
    {
        BioFuel_blue,
        BioFuel_green,
        BioFuel_yellow
    }

    public BioType bioType;
    public float Speed = 10f;
    public float followDistance = 5f;
    Vector2 _dir;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ComeBioFuel();
    }
    void ComeBioFuel()
    {
        /**
        GameObject bioPos = GameObject.Find("Item_Magnet");
        if (bioPos != null)
        {
            Debug.LogWarning("마그넷을 찾을 수 없음");
            // 마그넷과 바이오연료 간의 거리 계산
            float distance = Vector3.Distance(transform.position, bioPos.transform.position);
            Debug.LogWarning("거리 계산");

            if (distance <= followDistance)
            {
                Debug.LogWarning("따라가기");
                Vector3 playerDirection = (bioPos.transform.position - transform.position).normalized;
                transform.position += playerDirection * Speed * Time.deltaTime;
            }
        }
        else
        {
            Debug.LogWarning("마그넷을 찾을 수 없음");
        }
        **/
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            CollectBioFuel(player);
            Debug.Log("경험치 업");
        }
        else if (collision.CompareTag("Item_Magnet"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            CollectBioFuel(player);
            Debug.Log("마그넷으로 경험치 업");
        }
        else
        {
            return;
        }
    }
    void CollectBioFuel(Player player)
    {
        if (bioType == BioType.BioFuel_blue)
        {
            player.LevelCount += 1;
            gameObject.SetActive(false);
            Debug.Log($"캐릭터 경험치 : {player.LevelCount}");
        }
        else if (bioType == BioType.BioFuel_green)
        {
            player.LevelCount += 2;
            gameObject.SetActive(false);
            Debug.Log($"캐릭터 경험치 : {player.LevelCount}");
        }
        else
        {
            player.LevelCount += 3;
            gameObject.SetActive(false);
            Debug.Log($"캐릭터 경험치 : {player.LevelCount}");
        }
    }
}
