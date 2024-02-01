using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public int Per;

    public void Init(float damage, int per)
    {
        this.Damage = damage;
        this.Per = per;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
