using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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

    public float CoolTime;
    private Player _player;
    public GameObject Bullet_prefab;

    private float _timer;
    public Transform Target;
    private List<GameObject> _bulletPool;
    public int WeaponLevel;

    private bool _isFiring = false;
    private float _gapTimer = 0;
    private const float FIRE_GAP = 0.2f;
    private const int MAX_WEAPON_LEVEL = 5;
    private bool[] _enabledBullet = new bool[5];
    private int fireCount;


    public void GetLevelUPWeapon()
    {
        WeaponLevel++;
        Debug.Log($"WLevel= {WeaponLevel}");
    }

    private void Awake()
    {
        WeaponLevel = 1;
        _player = GetComponentInParent<Player>();
        _poolSize = 20;
        _bulletPool = new List<GameObject>();
        _timer = 0;
        fireCount = 0;
        CoolTime = 1.5f;
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
        _timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (WeaponLevel <= MAX_WEAPON_LEVEL)
            {
                GetLevelUPWeapon();
            }
        }
        if (WeaponLevel <= MAX_WEAPON_LEVEL)
        {
            RepeatFire(WeaponLevel);
        }
        else if (WeaponLevel == 6)
        {
            RepeatFire(1);
            CoolTime = 0.2f;
        }
    }

    private void RepeatFire(int numberOfShots)
    {

        for (int i = 0; i < numberOfShots; i++)
        {
            _enabledBullet[i] = true;
        }

        Target = _player.scanner.nearestTarget;

        if (_timer > CoolTime && Target != null && _isFiring == false) // 쿨타임당 첫발 사격
        {
            SingleFire();
            _isFiring = true;
            fireCount = 1;
        }

        if (_isFiring == true)
        {
            _timer = 0;
            _gapTimer += Time.deltaTime;

        }
        for (int i = 0; i < MAX_WEAPON_LEVEL; i++)
        {
            if (_enabledBullet[i] == true && _gapTimer > FIRE_GAP)
            {
                SingleFire();
                fireCount++;
                _gapTimer = 0;
            }
        }
        if (fireCount == numberOfShots)
        {
            _gapTimer = 0;
            _isFiring = false;
            fireCount = 0;
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
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Fire);
        //bullet.GetComponent<Kunai_bullet>().
        Kunai_bullet bulletinfo = bullet.GetComponent<Kunai_bullet>();
        bulletinfo.SetTarget(_player.scanner.nearestTarget);
        bulletinfo.Level = WeaponLevel;
        if (bulletinfo.Level == 6)
        {
            bulletinfo.WType = WeaponType.Kunai_Upgrade;
        }
        bullet.transform.position = this.transform.position;
        bullet.SetActive(true);
    }


}