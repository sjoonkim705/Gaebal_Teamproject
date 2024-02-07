using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public Item_UI itemUI;
    public int numberOfItems = 4; // 생성할 아이템의 개수

    // 랜덤 아이템 생성 메서드
    public void SpawnRandomItems(int numberOfItems)
    {
        // 랜덤으로 2개의 아이템 생성
        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, numberOfItems); // 0부터 numberOfItems - 1 사이의 랜덤한 index 생성
            itemUI.Select(randomIndex); // 생성된 랜덤한 index를 사용하여 아이템 선택
        }
    }
}
