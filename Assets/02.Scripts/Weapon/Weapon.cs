using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Kunai,
    Kunai_Upgrade,
    Shield,
    Shield_Upgrade,
}

public class Weapon : MonoBehaviour
{
    public float Damage;
    public int Count;
    public float Speed;


    public GameObject Bullet_prefab;
    private float _timer;
    public Transform Target;
    public WeaponType WType;

    private void Awake()
    {
        // player = GetComponentInParent<Player>();
       _timer = 0;
    }
    void Start()
    {
        Scanner scanner = GetComponentInParent<Scanner>();
        Target = scanner.nearestTarget;
    }

  
    void Update()
    {

          transform.Rotate(Vector3.back * Speed * Time.deltaTime);

    }
    public void Fire()
    {
        // Debug.Log("Fire");
        GameObject bullet = GameObject.Instantiate(Bullet_prefab);
        bullet.transform.SetParent(this.transform);
        bullet.transform.position = transform.position;
        //bullet.get
        // bullet.dir = 

    }
}
