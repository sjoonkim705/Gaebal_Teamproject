
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;

    public PoolManager pool;

    public Item_UI itemUi;
    public bool isLive;
    public Text GameOverUI;

    public GameObject GameOverImage;

    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        //GameOver GameOverImage = GetComponent<GameOver>();
        
        
        

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
           
            
            //itemUi.Select(Random.Range(0, itemUi.itemPrefabs.Length));

            //itemUi.Show();
            //itemUi.Select(0);



            // 레벨 올리기
            // player.PlayerLevel++;
        }
    }
    public void GameOver()
    {
        Stop();
        GameOverImage.SetActive(true);
        //GameOverUI.text = $"Game Over";
        
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
