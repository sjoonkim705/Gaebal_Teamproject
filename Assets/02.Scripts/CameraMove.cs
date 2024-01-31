using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 CameraPos;
    void Start()
    {
        CameraPos = transform.position;

    }

    void Update()
    {
        CameraPos.x = GameManager.Instance.player.transform.position.x;
        CameraPos.y = GameManager.Instance.player.transform.position.y;
        transform.position = CameraPos;

    }
}
