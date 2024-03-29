using UnityEngine;

public class healthController : MonoBehaviour
{
    public GameObject magnetEffectPrefab; // 마그넷 효과 프리팹

    // 마그넷 기능을 활성화하는 메서드
    public void ActivateMagnet()
    {
        // 마그넷 효과를 생성하거나, 마그넷 관련 로직을 실행합니다.
        Instantiate(magnetEffectPrefab);

        Debug.Log("Magnet activated!");
    }
}
