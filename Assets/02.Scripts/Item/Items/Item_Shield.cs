using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : MonoBehaviour
{
    public Animator ShieldAnimator;
    public float shieldRadius_lv1 = 1.5f;
    public float shieldRadius_lv2 = 2f;
    public float shieldRadius_lv3 = 3f;

    private CircleCollider2D circleCollider;

    private void Awake()
    {
        ShieldAnimator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {

        SetShieldRadius(shieldRadius_lv1);
    }

    private void LateUpdate()
    {
        Player player = FindObjectOfType<Player>();
        if (player.PlayerLevel <= 2)
        {
            SetShieldRadius(shieldRadius_lv2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HandleEnemyCollision(collision);
        }
    }

    public void SetShieldRadius(float radius)
    {
        if (circleCollider != null)
        {
            circleCollider.radius = radius;
        }
    }

    public void HandleEnemyCollision(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        enemy.Health--;

        if (enemy.Health <= 0)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    internal void HandleEnemyCollision()
    {
        throw new NotImplementedException();
    }
}
