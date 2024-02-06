using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_energydrink : MonoBehaviour
{
    public float _time;
    private float _fiveSecond = 5;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        EnergyDrinking();
    }

    public void EnergyDrinking()
    {
        _time += Time.deltaTime;

        if (_time >= _fiveSecond)
        {
            _time = 0;
            Player player = FindObjectOfType<Player>();
            player.PlayerHealth++;
            player.PlayerHealth = Mathf.Clamp(player.PlayerHealth, 0, player.PlayerMaxHealth);
            Debug.Log(player.PlayerHealth);
        }

    }

}
