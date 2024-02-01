using System.Collections;
using UnityEngine;

public class ParticleFuelManager : MonoBehaviour
{
    public GameObject BioFuel_blue; // BioFuel_blue 프리팹을 할당하기 위한 변수
    public int initialFuelCount = 100;
    public float spawnInterval = 0.1f; // 연료가 생성되는 간격
    public float spreadRadius = 5f;

    void Start()
    {
        StartCoroutine(SpawnFuelParticles());
    }

    IEnumerator SpawnFuelParticles()
    {
        for (int i = 0; i < initialFuelCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-spreadRadius, spreadRadius), 0f, Random.Range(-spreadRadius, spreadRadius));

            // BioFuel_blue 프리팹을 Instantiate 함수의 첫 번째 인자로 사용
            GameObject bioFuelParticle = Instantiate(BioFuel_blue, randomPosition, Quaternion.identity);

            // 파티클 시스템으로 설정된 BioFuel_blue 오브젝트의 Particle System 컴포넌트를 가져옴
            ParticleSystem particleSystem = bioFuelParticle.GetComponent<ParticleSystem>();

            // 파티클 시스템이 재생될 동안 대기
            yield return new WaitForSeconds(particleSystem.main.duration);
        }
    }
}


