using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public float interval = 0.2f;
    //private SpriteRenderer spriteRenderer;
    public Image StartImage;
    


    void Start()
    {
        StartImage = GetComponent<Image>();

        //GameManager.Instance.Stop();
        //StartImage = GetComponent<Image>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SwitchSprites());
    }
    public void Aaa() 
    {
        
        
        

    }

    IEnumerator SwitchSprites()
    {
        while (true)
        {
            // sprite1을 보여주고 기다리기
            StartImage.sprite = sprite1;
            yield return new WaitForSecondsRealtime(interval);

            // sprite2를 보여주고 기다리기
            StartImage.sprite = sprite2;
            yield return new WaitForSecondsRealtime(interval);
        }
    }
    public void ImageON()
    {
        StartImage.enabled = true;
    }
    public void ImageOFF()
    {
        StartImage.enabled = false;
    }
}
