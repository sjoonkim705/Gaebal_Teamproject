using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameStart : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public float switchInterval = 0.3f;
    private float _timer;
    private SpriteRenderer spriteRenderer;



    void Start()
    {
        GameManager.Instance.Stop();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.Resume();
            AudioManager.instance.PlayBgm(true);
        }


    }

}
    



