using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
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
    
    public float CoolTime;
    public bool isTargetType;
    public bool isPiercing;

    public Vector2 direction;

    public GameObject bullet_prefab;
    private float _timer;
    private Transform _target;
    public WeaponType WType;

    private void Awake()
    {
       isTargetType = true;
       _timer = 0;
    }
    void Start()
    {
        Scanner scanner = GameManager.Instance.player.GetComponent<Scanner>();
        _target = scanner.nearestTarget;
    }

    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer > CoolTime)
        {
            Fire();
            _timer = 0;
        }
    }
    public void Fire()
    {
        // Debug.Log("Fire");
        GameObject bullet = GameObject.Instantiate(bullet_prefab);
        bullet.transform.SetParent(this.transform);
        bullet.transform.position = transform.position;
        //bullet.get
        // bullet.dir = 

    }
}
