using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class Item_UI : MonoBehaviour
{

    RectTransform rect;
    Image image;

    public GameObject[] itemPrefabs; // 아이템 프리팹들을 저장할 배열

    public List<GameObject> CardList;

    // Start is called before the first frame updatez 
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponentInChildren<Image>();
        Hide();

    }
    private void Start()
    {
        
        /*        if (shieldItem != null)
                {
                    // Collider2D 변수를 얻어옴 (다른 스크립트에서 어떻게 가져올지에 따라 코드가 다를 수 있음)
                    Collider2D collisionCollider = GetCollisionCollider();

                    // SetShieldRadius 함수 호출
                    shieldItem.SetShieldRadius(2.5f);

                    // HandleEnemyCollision 함수 호출
                    shieldItem.HandleEnemyCollision(collisionCollider);
                }*/
    }

    public void Show()
    {
        GameManager.Instance.Stop();
        rect.localScale = Vector3.one;
        Debug.Log("UI나오나?");


        int randomIndex1 = -1;
        int randomIndex2 = -1;

        while(true)
        {
            randomIndex1 = UnityEngine.Random.Range(0, 4);
            randomIndex2 = UnityEngine.Random.Range(0, 4);
            if (GameManager.Instance.player.IsShieldOn == true && (randomIndex1 == 3 || randomIndex2 == 3))
            {
                continue;
            }
            if (GameManager.Instance.player.Weapons[0].WeaponLevel == 4 && GameManager.Instance.player.SpeedUpCount != 0)
            {
                randomIndex1 = 4; // 유령수리검
                randomIndex2 = 0; // 에너지회복
                break;
            }
            if (GameManager.Instance.player.Weapons[0].WeaponLevel == 6)
            {
                randomIndex1 = 0;
                randomIndex2 = 2;
                break;
            }
            if(randomIndex1 != randomIndex2)
            {
                break;
            }
        }

        foreach(GameObject card in CardList) 
        {
            card.gameObject.SetActive(false);
        }

        CardList[randomIndex1].gameObject.SetActive(true);
        CardList[randomIndex2].gameObject.SetActive(true);



    }
    public void Hide()
    {
        //image = GetComponentInChildren<Image>();
        //image.enabled = false;
        Debug.Log("UI사라지나?");
        rect.localScale = Vector3.zero;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.Resume();
        }
        else
        {
            Debug.Log("GameManager instance is null!");
        }
    }


    public void Select(int index)
    {
        Debug.Log($"Item {index} spawned.");

        switch (index)
        {
            case 0: // 헬스
            {
                /*                GameObject newItem = Instantiate(itemPrefabs[index], transform.position, Quaternion.identity);

                                Item_health healthItem = newItem.GetComponent<Item_health>(); // 수정
                                Collider2D collider2D = GetCollisionCollider();
                                newItem.SetActive(true); // 수정*/
                /*                if (healthItem != null)
                                {
                                    healthItem.HealthFull(GetComponent<Collider2D>());
                                    Debug.Log("Health Item spawned.");
                                }*/
                GameManager.Instance.player.PlayerHealth = GameManager.Instance.player.PlayerMaxHealth;
                break;
            }
                
            case 1: // 스피드
            {
                // GameObject newItem = Instantiate(itemPrefabs[index], transform.position, Quaternion.identity);

                /*                Item_shoes item_Shoes = newItem.GetComponent<Item_shoes>(); // 수정
                                newItem.SetActive(true); // 수정
                                if (item_Shoes != null)
                                {
                                    item_Shoes.ShoesSpeed();
                                    Debug.Log("스피드 증가");
                                }*/
                GameManager.Instance.player.IncreaseSpeed();
                break;
            }
               
            case 2: // 에너지
            {
                GameObject newItem = Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);

                Item_energydrink energyDrinkItem = newItem.GetComponent<Item_energydrink>(); // 수정
                newItem.SetActive(true); // 수정
                if (energyDrinkItem != null)
                {
                    energyDrinkItem.EnergyDrinking();
                    Debug.Log("에너지 증가");
                }
                Debug.Log("Energy Drink Item spawned.");
                break;
            }
                
            case 3: // 쉴드
            {
                GameObject newItem = Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);

                Item_Shield shieldItem = newItem.GetComponent<Item_Shield>(); // 수정
                newItem.SetActive(true); // 수정
                GameManager.Instance.player.IsShieldOn = true;
                Debug.Log("Sheild Item spawned.");
                break;
            }
               
            case 4: // 쿠나이 레벨업
                GameManager.Instance.player.Weapons[0].SetLevelUPWeapon();
                break;
            case 5:
                GameManager.Instance.player.Weapons[0].SetKunaiUpgrade();
                break;

            default:
                Debug.LogError("Invalid item index selected.");
                break;
        }

        Debug.Log($"{index}번 클릭");
    }


    /*   public void Select(int index)
       {
           // 아이템 선택에 대한 동작을 수행
           switch (index)
           {
               case 0:
                   Item_health healthItem = GetComponent<Item_health>();
                   Collider2D collider2D = GetCollisionCollider();
                   gameObject.SetActive(true);
                   if (healthItem != null)
                   {
                       healthItem.HealthFull(collider2D);
                       Debug.Log("체력 Full 충전!");
                   }

                   break;
               case 1:
                   Item_Shield shieldItem = GetComponent<Item_Shield>();
                   gameObject.SetActive(true);
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
                   gameObject.SetActive(true);
                   if (energyDrinkItem != null)
                   {
                       energyDrinkItem.EnergyDrinking();
                       Debug.Log("에너지 증가");
                   }
                   break; 
               case 3:
                   Item_shoes shoesItem = GetComponent<Item_shoes>();
                   gameObject.SetActive(true);
                   if (shoesItem != null)
                   {
                       shoesItem.ShoesSpeed();
                       Debug.Log("스피드 증가");
                   }
                   break;
           }
       }*/


    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭된 아이템을 활성화합니다.
        this.gameObject.SetActive(true);
    }
    Collider2D GetCollisionCollider()
    {
        // 실제로는 다른 스크립트에서 어떻게 Collider2D를 가져올지에 따라 코드가 달라질 수 있음
        // 필요에 따라 적절한 코드로 대체해주셔야 합니다.
        return GetComponent<Collider2D>();
    }
}
