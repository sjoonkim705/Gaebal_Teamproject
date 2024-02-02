using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : MonoBehaviour
{
    public Animator ShieldAnimator;
    public float shieldRadius_lv1 = 1.5f; 
    public float shieldRadius_lv2 = 2f;
    public float shieldRadius_lv3 = 3f;

    private void Awake()
    {
        ShieldAnimator = this.gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        // Sphere Collider를 찾아서 반경을 설정
        CircleCollider2D  circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = shieldRadius_lv1;
        }
    }

    private void LateUpdate()
    {
        Player player = FindObjectOfType<Player>();
        if (player.PlayerLevel <= 2)
        {

            CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
            if (circleCollider != null)
            {
                circleCollider.radius = shieldRadius_lv2;
            }
        }
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
