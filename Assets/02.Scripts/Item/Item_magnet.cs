using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_magnet : MonoBehaviour
{
    public float Speed;
    private Vector2 _dir;





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log($"아이템 생성");
            comeBioFuel();
        }

    }


    private void comeBioFuel()
    {

        GameObject biofuel = GameObject.Find("BioFuel");
        _dir = biofuel.transform.position - this.transform.position;
        _dir.Normalize();
        Vector2 newPosition = transform.position + (Vector3)(_dir * Speed) * Time.deltaTime;
        transform.position = newPosition;
    }
}
