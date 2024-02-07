using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public GameObject KunaiEffectPrefab; // 마그넷 효과 프리팹

    // 마그넷 기능을 활성화하는 메서드
    public void Activatekunai()
    {
        // 마그넷 효과를 생성하거나, 마그넷 관련 로직을 실행합니다.
        Instantiate(KunaiEffectPrefab);

        Debug.Log("Activatekunai activated!");
    }
}
