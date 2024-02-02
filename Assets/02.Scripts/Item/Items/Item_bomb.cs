using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_bomb : MonoBehaviour
{

    
    void Update()
    {
  

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(enemies.Length);
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                enemy.gameObject.SetActive(false);
                enemy.MakeBioFuel();
            }
            this.gameObject.SetActive(false);
        }


    }

}
