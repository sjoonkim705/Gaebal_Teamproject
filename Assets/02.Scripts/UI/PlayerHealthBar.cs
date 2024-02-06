using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    private Slider _mySlider;
    //private Player _player;
    private float _playerHealth;
    private float _MaxHealth;

    private void Awake()
    {
        //_player = GameManager.Instance.player.GetComponent<Player>();
        _mySlider = GetComponent<Slider>();

    }

    void Start()
    {
        _MaxHealth = GameManager.Instance.player.PlayerMaxHealth;
        _playerHealth = GameManager.Instance.player.PlayerHealth;
        _mySlider.value = _playerHealth / _MaxHealth;
        Debug.Log(_MaxHealth);
        Debug.Log(_playerHealth);
    }

    void LateUpdate()
    {
        _MaxHealth = GameManager.Instance.player.PlayerMaxHealth;
        _playerHealth = GameManager.Instance.player.PlayerHealth;
        _mySlider.value = _playerHealth/_MaxHealth;
    }
}
