using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }
    public Player player;

    public PoolManager pool;

    public Item_UI itemUi;
    public bool isLive;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 옵션: 씬이 변경되어도 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 중복 인스턴스 파괴
        }
    }
    void Start()
    {




    }

    void Update()
    {
        GetExp();
        if (player.PlayerHealth <= 0)
        {
            GameOver();
        }
    }

    public void GetExp()
    {
        // Player 컴포넌트 가져오기
        if (player == null)
        {
            Debug.LogError("Player component not found!");
            return;
        }

        int expRequired = (player.PlayerLevel + 1) * 10;

        // 레벨업 조건 확인
        if (player.LevelCount >= expRequired)
        {
            // 아이템 표시 및 선택
/*            itemUi.Show();
            itemUi.Select(3);*/

            // 레벨 올리기
           // player.PlayerLevel++;
        }
    }
    public void GameOver()
    {
        Stop();

    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
