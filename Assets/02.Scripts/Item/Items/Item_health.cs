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
        HealthFull();
    }

    public void HealthFull()
    {
        if (CompareTag("Player"))
        {
            Player player = gameObject.GetComponent<Player>();
            player._playerHealth = player.PlayerMaxHealth;
            Debug.Log(player._playerHealth);
            this.gameObject.SetActive(false);
        }
    }
}
