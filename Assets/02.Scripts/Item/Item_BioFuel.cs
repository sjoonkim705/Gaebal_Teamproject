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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.CompareTag("Enemy"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

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

        else
        {
            return;
        }
    }
}
