using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    public Image FlashImage;
    public float FlashSpeed = 2f;
    public Color FlashColor = new Color(1f, 1f, 1f, 1f);
    
    void Start()
    {
        FlashImage.color = Color.clear;
    }
    public void Flash() 
    {
        StartCoroutine(FlashCoroutine());
    }
    private IEnumerator FlashCoroutine() 
    {
        //Debug.Log("Flashing");
        FlashImage.color = new Color(FlashColor.r, FlashColor.g, FlashColor.b, 5f );

        float elapsedTime = 0f;

        while (elapsedTime < FlashSpeed)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / FlashSpeed);
            FlashImage.color = new Color(FlashColor.r, FlashColor.g, FlashColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        FlashImage.color = new Color(FlashColor.r, FlashColor.g, FlashColor.b, 0f);
        //Debug.Log("Flash finished");
    }
    
}
