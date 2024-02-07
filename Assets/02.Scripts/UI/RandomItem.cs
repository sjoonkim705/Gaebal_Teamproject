using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public Item_UI itemUI;
    public int numberOfItems = 4; // 생성할 아이템의 개수

    // 랜덤 아이템 생성 메서드
    public void SpawnRandomItems()
    {
        numberOfItems = itemUI.itemPrefabs.Length; // Item_UI 스크립트에서 프리팹 배열의 크기를 가져옵니다.
        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, numberOfItems);
            itemUI.Select(randomIndex);
        }
    }

}
