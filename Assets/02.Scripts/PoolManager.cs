using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();

        }
    }

    public GameObject Get(int i) 
    {
        // 선택된 GameObject를 저장할 변수
        GameObject select = null;

        // 풀 배열에 있는 오브젝트 확인
        foreach (GameObject item in pools[i]) 
        {
            // 비활성화된 오브젝트 찾으면
            if (!item.activeSelf) 
            {
                // 비어있는 곳에 넣고
                select = item;
                // 활성화
                select.SetActive(true);
                
                break;
            }
        }
        // 사용 가능한 오브젝트 없는 경우
        if (!select) 
        {
            // 새로운 오브젝트 생성하고
            select = Instantiate(prefabs[i]);
            // 풀에 추가
            pools[i].Add(select);

            
        }
        return select;
    }
}
