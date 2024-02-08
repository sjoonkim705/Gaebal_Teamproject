using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KunaiController : MonoBehaviour
{
    public Image MyImage;
    public Sprite[] mySprites;

    private void Start()
    {
        MyImage = GetComponent<Image>();
    }
    private void Update()
    {
        if (GameManager.Instance.player.Weapons[0].WeaponLevel == 1)
        {
            MyImage.sprite = mySprites[0];
        }
        else if (GameManager.Instance.player.Weapons[0].WeaponLevel == 2)
        {
            MyImage.sprite = mySprites[1];
        }
        else if (GameManager.Instance.player.Weapons[0].WeaponLevel == 3)
        {
            MyImage.sprite = mySprites[2];
        }

    }

}
