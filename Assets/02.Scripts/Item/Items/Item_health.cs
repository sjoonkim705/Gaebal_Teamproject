using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_health : MonoBehaviour
{
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
        HealthFull(collision);
    }

    public void HealthFull(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
<<<<<<< HEAD
            Player player = collision.gameObject.GetComponent<Player>();
=======
            Player player = collision.GetComponent<Player>();
>>>>>>> 116e023ae2ef468155a4410348d4c0fa93964812
            player.PlayerHealth = player.PlayerMaxHealth;
            Debug.Log(player.PlayerHealth);
            this.gameObject.SetActive(false);
        }
    }
}
