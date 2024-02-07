using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnUI : MonoBehaviour
{
    public Animator uianimator;
    public Image  uiImage;

    public Animator uianimator2;
    public Image uiImage2;

    public float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        uianimator = GetComponent<Animator>();
        uiImage = GetComponent<Image>();

        GameObject secondUIObject = GameObject.Find("Image2");
        if (secondUIObject != null) 
        {
            uianimator2 = GameObject.Find("Image2").GetComponent<Animator>();
            uiImage2 = GameObject.Find("Image2").GetComponent<Image>();

            SpriteOFF();
            HideUI();
        }
        
        
        
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 37f) 
        {
            SpriteON();
            ShowUI();
        }
        if (timeElapsed >= 40f) 
        {
            SpriteOFF();
            HideUI();
        }
        if (timeElapsed >= 60f) 
        {
            timeElapsed = 0f;
        }
    }
    public void ShowUI() 
    {
        uianimator.enabled = true;
        uianimator2.enabled = true;
        
    }
    public void HideUI() 
    {
        uianimator.enabled = false;
        uianimator2.enabled = false;
        
    }
    public void SpriteON() 
    {
        uiImage.enabled = true;
        uiImage2.enabled = true;
    }
    public void SpriteOFF() 
    {
        uiImage.enabled = false;
        uiImage2.enabled = false;
    }
   
}
