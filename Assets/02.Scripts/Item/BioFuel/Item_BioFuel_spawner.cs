using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BioFuel_spawner : MonoBehaviour
{

    public GameObject BioFuel_blue;
    public GameObject BioFuel_green;
    public GameObject BioFuel_yellow;
    public int initialFuelCount = 10;
    public int poolSize = 20;
    public float spreadRadius = 5f; // 흩뿌릴 범위 조절




        void Start()
    {
        initialFuelPool();
    }

    void initialFuelPool()
    {
        for (int i = 0; i < initialFuelCount; i++)
        {
            GameObject biofuel = Instantiate(BioFuel_blue);
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
            biofuel.transform.position = randomPosition;
            biofuel.SetActive(true);

        }


    }


    // Update is called once per frame
    void Update()
    {
  
        
    }
}
