using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BioFuel : MonoBehaviour
{


    float randomX;
    float randomY;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetRandomPosition()
    {
        randomX = Random.Range(1, 10);
        randomY = Random.Range(1, 10);
        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Health += 1;
            gameObject.SetActive(false);
            Debug.Log($"캐릭터 체력 : {player.Health}");
        }

        else
        {
            return;
        }
    }
}
