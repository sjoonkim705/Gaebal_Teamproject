using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class Item_UI : MonoBehaviour, IPointerClickHandler
{

    RectTransform rect;
    Image image;

    public List<Item> itemList;

    public Item_energydrink Energydrink;
    public Item_shoes shoes;
    public Item_Shield shieldItem;
    public Item_magnet Magnet;
  
    // Start is called before the first frame updatez 
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponentInChildren<Image>();
        Hide();
        Energydrink = GetComponent<Item_energydrink>();
        shoes = GetComponent<Item_shoes>();
        shieldItem = GetComponent<Item_Shield>();
        Magnet = GetComponent<Item_magnet>();
    }
    private void Start()
    {
        if (shieldItem != null)
        {
            // Collider2D 변수를 얻어옴 (다른 스크립트에서 어떻게 가져올지에 따라 코드가 다를 수 있음)
            Collider2D collisionCollider = GetCollisionCollider();

            // SetShieldRadius 함수 호출
            shieldItem.SetShieldRadius(2.5f);

            // HandleEnemyCollision 함수 호출
            shieldItem.HandleEnemyCollision(collisionCollider);
        }
    }
    public void OnClickDRINK()
    {
        /*        Item_energydrink energyDrinkItem = GetComponent<Item_energydrink>();
                energyDrinkItem.EnergyDrinking();*/
        rect.localScale = Vector3.one;
        GameManager gameManager = GameManager.Instance;
        GameManager.Instance.Stop();
        Debug.Log("click");
    }
    public void Show()
    {
        rect.localScale = Vector3.one;
        Debug.Log("UI나오나?");
        // 이미지 컴포넌트가 null이 아닌 경우에만 활성화합니다.
        if (image != null)
        {
            image.enabled = true; // 이미지를 활성화합니다.
        }
        else
        {
            Debug.LogError("Image component is null!");
        }

        GameManager.Instance.Stop();
    }
    public void Hide()
    {
        image = GetComponentInChildren<Image>();
        image.enabled = false;
        Debug.Log("UI사라지나?");
        rect.localScale = Vector3.zero;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.Resume();
        }
        else
        {
            Debug.LogError("GameManager instance is null!");
        }
    }
    public void Select(int index)
    {
        // 아이템 선택에 대한 동작을 수행
        switch (index)
        {
            case 0:
                Item_health healthItem = GetComponent<Item_health>();
                Collider2D collider2D = GetCollisionCollider();
                // gameObject.SetActive(true);
                if (healthItem != null)
                {
                    healthItem.HealthFull(collider2D);
                    Debug.Log("체력 Full 충전!");
                }

                break;
            case 1:
                Item_Shield shieldItem = GetComponent<Item_Shield>();
                // gameObject.SetActive(true);
                if (shieldItem != null)
                {
                    Collider2D collisionCollider = GetCollisionCollider();
                    shieldItem.HandleEnemyCollision(collisionCollider);
                    shieldItem.SetShieldRadius(2.5f);
                    Debug.Log("방어력 생성");
                }
                break;
            case 2:
                Item_energydrink energyDrinkItem = GetComponent<Item_energydrink>();
                // gameObject.SetActive(true);
                if (energyDrinkItem != null)
                {
                    energyDrinkItem.EnergyDrinking();
                    Debug.Log("에너지 증가");
                }
                break; 
            case 3:
                Item_shoes shoesItem = new Item_shoes();
               
                // gameObject.SetActive(true);
                if (shoesItem != null)
                {
                    shoesItem.ShoesSpeed();
                    Debug.Log("스피드 증가");
                }
                break;
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭된 아이템을 활성화합니다.
        shieldItem.gameObject.SetActive(true);
    }
    Collider2D GetCollisionCollider()
    {
        // 실제로는 다른 스크립트에서 어떻게 Collider2D를 가져올지에 따라 코드가 달라질 수 있음
        // 필요에 따라 적절한 코드로 대체해주셔야 합니다.
        return GetComponent<Collider2D>();
    }
}
