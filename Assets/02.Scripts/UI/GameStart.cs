using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameStart : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public float interval = 0.2f;
    private SpriteRenderer spriteRenderer;



    void Start()
    {
        GameManager.Instance.Stop();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SwitchSprites());

    }


    IEnumerator SwitchSprites()
    {
        while (true)
        {
            // sprite1을 보여주고 기다리기
            spriteRenderer.sprite = sprite1;
            yield return new WaitForSecondsRealtime(interval);

            // sprite2를 보여주고 기다리기
            spriteRenderer.sprite = sprite2;
            yield return new WaitForSecondsRealtime(interval);
        }
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
    



