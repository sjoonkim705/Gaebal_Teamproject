using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Weapon_Upgraded : MonoBehaviour
{

    private int _poolSize;
    public float Damage;

    public float CoolTime;
    private Player _player;
    public GameObject Bullet_prefab;

    private float _timer;
    public Transform Target;
    private List<GameObject> _bulletPool;


    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _poolSize = 20;
        _bulletPool = new List<GameObject>();
        _timer = 0;
        CoolTime = 0.2f;
    }
    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject kunai = GameObject.Instantiate(Bullet_prefab);
            _bulletPool.Add(kunai);
            kunai.SetActive(false);
        }
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > CoolTime)
        {
            SingleFire();
            _timer = 0;
        }
    }
    public void SingleFire()
    {

        if (!_player.scanner.nearestTarget)
        {
            return;
        }

        GameObject bullet = null;
        foreach (GameObject b in _bulletPool)
        {
            if (b.activeInHierarchy == false)
            {
                bullet = b;
                break;
            }
        }
        bullet.GetComponent<Kunai_Upgraded_bullet>().SetTarget(_player.scanner.nearestTarget);
        bullet.transform.position = this.transform.position;
        bullet.SetActive(true);
    }
}


