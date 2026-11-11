using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Đây là phần của Singleton
    public static GameManager _i;
    public bool isPaused;
    public bool isWin;
    public bool isEndGame;
    public int enemiesKilled = 0;
    [SerializeField] private GameObject winPopup;
    [SerializeField] private TMP_Text winScoreText;
    [SerializeField] private PlayerPlane playerPlane;
    [SerializeField] private GameObject loseGame;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text enemyKillText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text loseKillText;
    [SerializeField] private TMP_Text loseScoreText;
    [SerializeField] private Sprite[] stageClear;
    [SerializeField] private Image currentStage;
    [SerializeField] private GameObject StageClearCard;
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool isStageClearActive;
    public int lastStage = 0;
    
    public void Awake()
    {
        _i = this;
    }
    public void BeginGame()
    {
        Debug.Log("GameManager begin");
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("MenuScene");
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isStageClearActive)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                StageClearCard.SetActive(false);
                isStageClearActive = false;
                timer = 0;
            }

        }
        UpdateHUD();
        StageClearShow();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseGame();
            Debug.Log(isPaused);
        }

    }
    public void EnemyKilled()
    {
        if (isEndGame) return;
        enemiesKilled++;
        Debug.Log($"Enemy bị tiêu diệt: {enemiesKilled}/10");

        if (enemiesKilled >= 16)
        {
            isEndGame = true;
            isWin = true;
            winScoreText.text = "SCORE: " + playerPlane.point;
            winPopup.SetActive(true);
            Debug.Log("Bạn thắng");
        }
    }
    public void PlayerDied()
    {
        if (isEndGame) return;
        isWin = false;
        isEndGame = true;
        loseScoreText.text = $"Score: {playerPlane.point}";
        loseKillText.text = $"Kill: {enemiesKilled}/10";
        loseGame.SetActive(true);
        Debug.Log("Bạn thua!");
    }

    public void UpdateHUD()
    {
        healthText.text = $"HP: {playerPlane.health}/10";
        scoreText.text = $"Score: {playerPlane.point}";
        enemyKillText.text = $"Enemies: {enemiesKilled}/10";
        levelText.text = $"Level: {playerPlane.bulletLevel}/3";
    }

    public void StageClearShow()
    {
        if (enemiesKilled == 5 && lastStage < 5)
        {
            currentStage.sprite = stageClear[0];
            StageClearCard.SetActive(true);
            isStageClearActive = true;
            lastStage = 5;
        }
        else if (enemiesKilled == 10 && lastStage < 10)
        {
            currentStage.sprite = stageClear[1];
            StageClearCard.SetActive(true);
            isStageClearActive = true;
            lastStage = 10;
        }
        else if (enemiesKilled == 15 && lastStage < 15)
        {
            currentStage.sprite = stageClear[2];
            StageClearCard.SetActive(true);
            isStageClearActive = true;
            lastStage = 15;
            
        }

    }
}
