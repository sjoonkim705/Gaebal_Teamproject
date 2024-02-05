using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_UI : MonoBehaviour
{

    RectTransform rect;
    public Item_Shield shieldItem;
    // Start is called before the first frame update
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        shieldItem = GetComponent<Item_Shield>();
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

    public void Show()
    {
        rect.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }
    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.Instance.Resume();
    }
    public void Select(int index)
    {
        // 아이템 선택에 대한 동작을 수행
        switch (index)
        {
            case 0:
                Item_health healthItem = GetComponent<Item_health>();
                if (healthItem != null)
                {
                    healthItem.HealthFull();
                }

                break;
            case 1:
                Item_Shield shieldItem = GetComponent<Item_Shield>();
                if (shieldItem != null)
                {
                    Collider2D collisionCollider = GetCollisionCollider();
                    shieldItem.HandleEnemyCollision(collisionCollider);
                    shieldItem.SetShieldRadius(2.5f);
                }
                break;
            case 2:
                Item_energydrink energyDrinkItem = GetComponent<Item_energydrink>();
                if (energyDrinkItem != null)
                {
                    energyDrinkItem.EnergyDrinking();
                }
                break; 
            case 3:
                Item_shoes shoesItem = GetComponent<Item_shoes>();
                if (shoesItem != null)
                {
                    shoesItem.ShoesSpeed();
                }
                break;
        }
    }
    Collider2D GetCollisionCollider()
    {
        // 실제로는 다른 스크립트에서 어떻게 Collider2D를 가져올지에 따라 코드가 달라질 수 있음
        // 필요에 따라 적절한 코드로 대체해주셔야 합니다.
        return GetComponent<Collider2D>();
    }
}
