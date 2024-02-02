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
    private int _poolSize;
    public float Damage;
    public int Count;
    public float CoolTime;
    private Player _player;
    public GameObject Bullet_prefab;
    private float _timer;
    public Transform Target;
    public WeaponType WType;
    private List<GameObject> _bulletPool;


    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _poolSize = 20;
        _bulletPool = new List<GameObject>();
       _timer = 0;
        if (WType == WeaponType.Kunai)
        {
            CoolTime = 1.0f;
        }
        else if (WType == WeaponType.Kunai_Upgrade)
        {
            CoolTime = 0.2f;
        }
    }
    void Start()
    {

        for (int i = 0; i < _poolSize; i++)
        {
                GameObject kunai = GameObject.Instantiate(Bullet_prefab);
                _bulletPool.Add(kunai);
                kunai.SetActive(false);
        }

    }

  
    void Update()
    {
        Target = _player.scanner.nearestTarget;
        _timer += Time.deltaTime;
        if (_timer > CoolTime && Target != null)
        {
            Fire();
            _timer = 0;
        }

    }
    public void Fire()
    {
        if (!_player.scanner.nearestTarget)
        {
            return;
        }
        // GameObject bulletObject = GameObject.Instantiate(Bullet_prefab);
        // bullet.transform.SetParent(this.transform);
        //bulletObject.transform.position = transform.position;
        // Kunai_bullet kunai = bulletObject.GetComponent<Kunai_bullet>();
        // kunai.Target = Target;
        GameObject bullet = null;
        foreach (GameObject b in _bulletPool)
        {
            if (b.activeInHierarchy == false)
            {
                bullet = b;
                break;
            }
        }

        bullet.GetComponent<Kunai_bullet>().SetTarget(_player.scanner.nearestTarget);
        bullet.transform.position = this.transform.position;
        bullet.SetActive(true);



    }
}
