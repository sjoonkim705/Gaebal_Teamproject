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
        GameObject[] magnet = GameObject.FindGameObjectsWithTag("Item_Magnet");
       // Debug.Log($"마그넷 찾음");


        for (int i = 0; i < magnet.Length; i++)
        {
            Item_magnet magnetLogic = magnet[i].GetComponent<Item_magnet>();
         //   Debug.Log($"마그넷 계산");

            _dir = magnetLogic.transform.position - transform.position;
            _dir.Normalize();



            Vector2 newPosition = transform.position + (Vector3)(_dir * Speed) * Time.deltaTime;
            transform.position = newPosition;
         //   Debug.Log($"마그넷을 따라가게");


            // transform.position += (Vector3)(_dir * Speed) * Time.deltaTime;

            
        }


    }





    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            CollectBioFuel(player);
            // Debug.Log("경험치 업");

        }



        /**
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            CollectBioFuel(player);
            // Debug.Log("경험치 업");

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
        **/

    }
        public void CollectBioFuel(Player player)
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.ExpItem);
        if (bioType == BioType.BioFuel_blue)
        {
            player.LevelCount += 1;
            gameObject.SetActive(false);
            // Debug.Log($"캐릭터 경험치 : {player.LevelCount}");
        }
        else if (bioType == BioType.BioFuel_green)
        {
            player.LevelCount += 2;
            gameObject.SetActive(false);
           // Debug.Log($"캐릭터 경험치 : {player.LevelCount}");
        }
        else
        {
            player.LevelCount += 3;
            gameObject.SetActive(false);
           // Debug.Log($"캐릭터 경험치 : {player.LevelCount}");
        }
    }
}
