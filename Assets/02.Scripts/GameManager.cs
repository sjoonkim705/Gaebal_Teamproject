using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;

    public PoolManager pool;

    public Item_UI itemUi;
    public bool isLive;

    private void Awake()
    {
        Instance = this;

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


             itemUi.Show();
            itemUi.Select(1);
            itemUi.Select(3);

            /*            itemUi.Show();
                        itemUi.Select(0);*/



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
