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
    public float CoolTime;

    public GameObject Bullet_prefab;
    private float _timer;
    public Transform Target;
    public WeaponType WType;
    Scanner _scanner;


    private void Awake()
    {
        // player = GetComponentInParent<Player>();
       _timer = 0;
        if (WType == WeaponType.Kunai || WType == WeaponType.Kunai_Upgrade)
        {
            CoolTime = 1.0f;

        }
    }
    void Start()
    {
        if (WType == WeaponType.Kunai || WType == WeaponType.Kunai_Upgrade)
        {
            CoolTime = 1.0f;
            _scanner = GetComponentInParent<Scanner>();
            Target = _scanner.nearestTarget;
        }

    }

  
    void Update()
    {
        Target = _scanner.nearestTarget;
        _timer += Time.deltaTime;
        if (_timer > CoolTime && Target != null)
        {
            //Debug.Log($"{Target.transform.position.x} {Target.transform.position.y}");
            Fire();
            _timer = 0;
        }

    }
    public void Fire()
    {
        // Debug.Log("Fire");
        GameObject bulletObject = GameObject.Instantiate(Bullet_prefab);
        //bullet.transform.SetParent(this.transform);
        bulletObject.transform.position = transform.position;
        Kunai_bullet kunai = bulletObject.GetComponent<Kunai_bullet>();
        kunai.Target = Target;

    }
}
