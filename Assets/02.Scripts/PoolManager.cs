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
        for (int i=0;i<pools.Length;i++)
        {
            pools[i] = new List<GameObject>();

        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
