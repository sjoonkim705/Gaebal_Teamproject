using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    private Slider _mySlider;
    private float _playerHealth;
    private float _MaxHealth;
    public Image HealthBarFill;


    private void Awake()
    {
        _mySlider = GetComponent<Slider>();
        //HealthBarFill = GetComponent<Image>();


    }

    void Start()
    {
        _MaxHealth = GameManager.Instance.player.PlayerMaxHealth;
        _playerHealth = GameManager.Instance.player.PlayerHealth;
        _mySlider.value = _playerHealth / _MaxHealth;
       // Debug.Log(_MaxHealth);
       // Debug.Log(_playerHealth);
    }

    void LateUpdate()
    {
        _MaxHealth = GameManager.Instance.player.PlayerMaxHealth;
        _playerHealth = GameManager.Instance.player.PlayerHealth;
        _mySlider.value = _playerHealth/_MaxHealth;
        if (_mySlider.value > 0.8f)
        {
            HealthBarFill.color = Color.green;
        }
        else if ( _mySlider.value > 0.4f)
        {
            HealthBarFill.color = Color.yellow;
        }
        else
        {
            HealthBarFill.color = Color.red;
        }
    }
}
