using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitUI : MonoBehaviour
{
    public Animator uianimator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteOFF();
        uianimator = GetComponent<Animator>();
        HideUI();

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
        spriteRenderer.enabled = true;
    }
    public void SpriteOFF()
    {
        spriteRenderer.enabled = false;
    }
}
