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
    public int Level;

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
            dir = Target.transform.position - GameManager.Instance.player.transform.position;
            dir = dir.normalized;
            float radianTarget = Mathf.Atan2(dir.y, dir.x); // 총알이 적 방향을 향함

            float degreeTarget = radianTarget * Mathf.Rad2Deg;
            transform.rotation = UnityEngine.Quaternion.Euler(new Vector3(0, 0, degreeTarget));
        }

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
