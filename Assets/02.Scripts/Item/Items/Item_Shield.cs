using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : MonoBehaviour
{
    public Animator ShieldAnimator;

    private void Awake()
    {
        ShieldAnimator = this.gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Health--;
            if (enemy.Health <= 0)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }

}
