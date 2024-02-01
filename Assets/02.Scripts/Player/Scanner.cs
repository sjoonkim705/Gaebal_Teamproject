using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float ScanRange;
    public LayerMask TargetLayer;
    public RaycastHit2D[] Targets;
    public Transform nearestTarget;
    public const float DEFAULT_DISTANCE = 100;
    private void Awake()
    {
       //TargetLayer = 
    }
    private void FixedUpdate()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        nearestTarget = GetNearest();

    }

    Transform GetNearest()              // 가장 가까운 적 찾는 함수
    {
        Transform result = null;
        float diff = DEFAULT_DISTANCE;

        foreach (RaycastHit2D target in Targets)      
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float currentDiff = Vector3.Distance(myPos, targetPos);

            if (currentDiff < diff)
            {
                diff = currentDiff;
                result = target.transform;
            }
        }

        return result;
    }

}
