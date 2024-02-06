using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnUI : MonoBehaviour
{
    public Animator uianimator;
    public Image  uiImage;

    public float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        uiImage = GetComponent<Image>();
        SpriteOFF();
        uianimator = GetComponent<Animator>();
        HideUI();
        
    }
    private void Update()
    {
        /**timeElapsed += Time.deltaTime;
        if (timeElapsed >= 3f) 
        {
            SpriteON();
            ShowUI();
        }
        if (timeElapsed >= 5f) 
        {
            SpriteOFF();
            HideUI();
        }**/
    }
    public void ShowUI() 
    {
        uianimator.enabled = true;
        
    }
    public void HideUI() 
    {
        uianimator.enabled = false;
        
    }
    public void SpriteON() 
    {
        uiImage.enabled = true;
    }
    public void SpriteOFF() 
    {
        uiImage.enabled = false;
    }
   
}
