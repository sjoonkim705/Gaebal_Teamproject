using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public enum InfoType
    {
        Exp, Level, Kill, Time, Health
    }
    public InfoType type;

    Text myText;
    Slider mySlider;
    public Sprite[] images;
    private Image _imageComponent;


    private void Awake()
    {
       myText = GetComponent<Text>();
       mySlider = GetComponent<Slider>();
       _imageComponent = GetComponent<Image>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.Instance.player.LevelCount;
                float maxExp = GameManager.Instance.player.expRequired;
                int sliderValue = (int)curExp * 20 / (int)maxExp;
                _imageComponent.sprite = images[sliderValue];
                // Debug.Log(sliderValue);
                break;            

            case InfoType.Level:
                string level = GameManager.Instance.player.PlayerLevel.ToString();
                myText.text = string.Format($"{level}");
                break;       
            case InfoType.Kill:
                break; 
            case InfoType.Time:
                break; 
            case InfoType.Health:
                break;

        }
    }

}
