using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameStart : MonoBehaviour
{
    public float shakeDuration;
    public float shakeAmount;
    public float decreaseFactor;

    private Vector3 originalPosition;

    void Start()
    {
        shakeDuration = 0.5f;
        shakeAmount = 0.05f;
        decreaseFactor = 1.0f;

        GameManager.Instance.Stop();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            // 위치를 랜덤하게 흔들린 위치로 변경
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = originalPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.Resume();
        }
    }

    public void StartShake()
    {
        originalPosition = transform.position;
        shakeDuration = 0.5f;
    }
}
    



