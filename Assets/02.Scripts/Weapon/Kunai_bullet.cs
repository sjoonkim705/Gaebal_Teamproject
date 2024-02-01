using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai_bullet : MonoBehaviour
{
    public Vector2 dir;
    public float Speed = 3f;
    public Transform Target;
    void Start()
    {
        dir = Target.transform.position - GameManager.Instance.player.transform.position;
        dir = dir.normalized;
        float radianTarget = Mathf.Atan2(dir.y, dir.x);

        float degreeTarget = radianTarget * Mathf.Rad2Deg;
        transform.rotation = UnityEngine.Quaternion.Euler(new Vector3(0, 0, degreeTarget));




    }

    void FixedUpdate()
    {
        Vector3 newPos = dir * Speed * Time.fixedDeltaTime;
        transform.position += newPos;
    }
}
