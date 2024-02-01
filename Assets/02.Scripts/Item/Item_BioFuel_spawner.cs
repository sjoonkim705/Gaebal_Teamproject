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
            GameObject bioFuel = biofuelPool[i];
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
            bioFuel.transform.position = randomPosition;
            bioFuel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
  
        
    }
}
