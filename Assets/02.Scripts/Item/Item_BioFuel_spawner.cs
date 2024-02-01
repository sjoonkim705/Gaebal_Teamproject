using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BioFuel_spawner : MonoBehaviour
{

    public GameObject BioFuel_blue;
    public GameObject BioFuel_green;
    public GameObject BioFuel_yellow;
    public int initialFuelCount = 999;
    public int poolSize = 1000;
    public float spreadRadius = 5f; // 흩뿌릴 범위 조절

    private List<GameObject> biofuelPool = new List<GameObject>();


        void Start()
    {
        initialFuelPool();
        spawninitialFuel();
    }

    void initialFuelPool() 
    {
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject biofuel = Instantiate(BioFuel_blue);
            biofuel.SetActive(false);
            biofuelPool.Add(biofuel);
        }
        
    }

    void spawninitialFuel() 
    {
        for (int i = 0; i < initialFuelCount; i++)
        {
            float angle = Random.Range(0f, Mathf.PI * 2f); // 0에서 360도 사이의 무작위 각도
            float distance = Random.Range(0f, spreadRadius); // 중심으로부터의 거리
            GameObject bioFuel = biofuelPool[i];
            Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0f);
            bioFuel.transform.position = randomPosition;
            bioFuel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
  
        
    }
}
