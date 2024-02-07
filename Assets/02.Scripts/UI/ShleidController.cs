using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShleidController : MonoBehaviour
{

        public GameObject ShleidPrefab; // 마그넷 효과 프리팹

        // 마그넷 기능을 활성화하는 메서드
        public void ActivateShleid()
        {
            this.gameObject.SetActive(true);
            Instantiate(ShleidPrefab);

            Debug.Log("Shleid activated!");
        }
    
}
