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
    private GameObject _target;
    private bool attractedToMagnet = false;
    private Transform magnetTransform;
    private float magnetStrength;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attractedToMagnet && magnetTransform != null)
        {
            Vector3 direction = (magnetTransform.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;
        }
        ComeBioFuel();
    }

    public void AttractToMagnet(Vector3 magnetPosition, float strength)
    {
        attractedToMagnet = true;
        magnetTransform.transform.position += Vector3.right; // 여기서 자석의 Transform을 설정해도 됩니다. 예를 들면, magnetTransform = magnetTransform;
        magnetStrength = strength;
    }
    void ComeBioFuel()
    {

        /**
        
        GameObject bioPos = GameObject.Find("Item_Magnet");
        if (bioPos != null)
        {
                Debug.LogWarning("따라가기");
                Vector3 playerDirection = (bioPos.transform.position - transform.position).normalized;
                transform.position += playerDirection * Speed * Time.deltaTime;
        }
        else
        {
            Debug.LogWarning("마그넷을 찾을 수 없음");
        }
     **/
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
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
    }
    public void CollectBioFuel(Player player)
    {
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
