using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BioFuel : MonoBehaviour
{
    public enum BioType // 바이오 연료 타입    
    {
        BioFuel_blue,
        BioFuel_green,
        BioFuel_yellow
    }

    public BioType bioType;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ComeBioFuel()
    {
        GameObject biofuel = GameObject.Find("BioFuel");
        if (biofuel != null)
        {
            Vector3 bioPos = biofuel.transform.position;
            Vector3 comeBio = (bioPos - transform.position).normalized;
            transform.position += comeBio * Speed * Time.deltaTime;
            biofuel.SetActive(false);
        }



    }
}
