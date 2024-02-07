using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai_bullet : MonoBehaviour
{
    public Vector2 dir;
    private float _bulletSpeed = 13f;
    public Transform Target;
    public WeaponType WType;
    public SpriteRenderer mySpriteRender;
    public Sprite KunaiUpgradeSprite;
    public int Level;
    //private GameObject _vfx;


    public GameObject BulletVFXPrefab;

    public void SetBulletSpeed(float speed)
    {
        _bulletSpeed = speed;
        if (speed <= 0) { return; }

    }
    public void SetTarget(Transform target)
    {
        Target = target;
    }

    private void Awake()
    { 
    }

    void OnEnable()
    {
        if (Target != null)
        {
            if (Level == 6) // kunai_upgraded 초기화
            {
                WType = WeaponType.Kunai_Upgrade;
                mySpriteRender = GetComponent<SpriteRenderer>();
                mySpriteRender.sprite = KunaiUpgradeSprite;
                SetBulletSpeed(15f);
              //  _vfx = GameObject.Instantiate(BulletVFXPrefab);
              //  _vfx.transform.parent = this.transform;
            }
            dir = Target.transform.position - GameManager.Instance.player.transform.position;
            dir = dir.normalized;
            float radianTarget = Mathf.Atan2(dir.y, dir.x); // 총알이 적 방향을 향함

            float degreeTarget = radianTarget * Mathf.Rad2Deg;
            transform.rotation = UnityEngine.Quaternion.Euler(new Vector3(0, 0, degreeTarget));
        }

    }
    void OnDisable()
    {
      //  Destroy(_vfx);
    }

    void FixedUpdate()
    {
        Vector3 newPos = dir * _bulletSpeed * Time.fixedDeltaTime;
        transform.position += newPos;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))   // 총알이 영역 밖으로 나가면 destroy
        {
            this.gameObject.SetActive(false);
        }
    }

}
