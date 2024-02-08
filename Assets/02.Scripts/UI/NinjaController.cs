using UnityEngine;
using UnityEngine.UI;

public class NinjaController : MonoBehaviour
{
    public Image MyImage;
    public Sprite[] mySprites;
    private void Start()
    {
        MyImage = GetComponent<Image>();
    }
    private void Update()
    {
        if (GameManager.Instance.player.SpeedUpCount == 0)
        {
            MyImage.sprite = mySprites[0];
        }
        else if (GameManager.Instance.player.SpeedUpCount == 1)
        {
            MyImage.sprite = mySprites[1];
        }
        else if (GameManager.Instance.player.SpeedUpCount == 2)
        {
            MyImage.sprite = mySprites[2];
        }
        else if (GameManager.Instance.player.SpeedUpCount == 3)
        {
            MyImage.sprite = mySprites[3];
        }

    }
    // 마그넷 기능을 활성화하는 메서드

}
