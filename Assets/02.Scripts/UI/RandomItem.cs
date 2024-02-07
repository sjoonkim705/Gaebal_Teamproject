using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public Item_UI itemUI;

    private void Start()
    {
      //   SpawnRandomItems();
    }

    private void Update()
    {

    }




    // 랜덤 아이템 생성 메서드
 /* public void SpawnRandomItems()
    {
        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, itemUI.itemPrefabs.Length);
            randomIndex.Yield();
        }
    }*/
    /*    private void SpawnImagesForLevel(int level)
        {
            // 레벨에 따라 왼쪽, 오른쪽, 또는 양쪽에 이미지 배치
            // 예시: 모든 레벨 업에서 왼쪽과 오른쪽에 이미지 배치
            Instantiate(imagePrefab, leftImagePosition.position, Quaternion.identity, leftImagePosition);
            Instantiate(imagePrefab, rightImagePosition.position, Quaternion.identity, rightImagePosition);
        }

        public void SelectAndPosition(int itemIndex, Vector2 position)
        {
            if (itemIndex >= 0 && itemIndex < itemUI.itemPrefabs.Length)
            {
                GameObject newItem = Instantiate(itemUI.itemPrefabs[itemIndex], transform);
                RectTransform itemRect = newItem.GetComponent<RectTransform>(); // 새로 생성된 아이템의 RectTransform

                itemRect.anchoredPosition = position; // 지정된 위치로 설정
                itemRect.sizeDelta = new Vector2(400, 800); 

                Debug.Log($"Item {itemIndex} spawned at position {position}.");
            }
        }*/


}
