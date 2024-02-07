using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnegyController : MonoBehaviour
{
    public GameObject energyPrefab; 

    
    public void Activatenergy()
    {
  
        Instantiate(energyPrefab);
        Item_energydrink item_Energydrink = gameObject.AddComponent<Item_energydrink>();
        item_Energydrink.EnergyDrinking();

        Debug.Log("Energy activated!");
       
    }
}