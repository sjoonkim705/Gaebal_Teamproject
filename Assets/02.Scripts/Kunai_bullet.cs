using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai_bullet : MonoBehaviour
{
    public Vector2 dir;
    public float Speed = 3f;
    public Transform target;
    void Start()
    {
        target = GameManager.Instance.player.GetComponent<Scanner>().nearestTarget;
        
    }

    void FixedUpdate()
    {
        Vector3 newPos = dir * Speed * Time.fixedDeltaTime;
        transform.position += newPos;
    }
}
