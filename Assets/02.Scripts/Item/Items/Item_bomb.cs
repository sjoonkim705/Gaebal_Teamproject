using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_bomb : MonoBehaviour
{
    private FlashEffect _flashEffect;

    private void Start()
    {
        _flashEffect = FindObjectOfType<FlashEffect>();
    }

    void Update()
    {
  

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Bomb);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                enemy.gameObject.SetActive(false);
                enemy.MakeBioFuel();
                
            }

            _flashEffect.Flash();
            this.gameObject.SetActive(false);
        }


    }

}
