using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    // Đây là phần của Singleton
    public static GameManager _i;
    public bool isPaused;
    public bool isWin;
    public bool isEndGame;
    public int enemiesKilled = 0;
    public GameObject winPopup;
    public TMP_Text winScoreText;
    public PlayerPlane playerPlane;
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log($"Enemy bị tiêu diệt: {enemiesKilled}/5");

        if (enemiesKilled >= 10)
        {
            isEndGame = true;
            isWin = true;
            winScoreText.text = "SCORE: " + playerPlane.point;
            winPopup.SetActive(true);
            Debug.Log("Ban thắng");
        }
    }
    public void PlayerDied()
    {
        if (isEndGame) return;
        isWin = false;
        isEndGame = true;
        Debug.Log("bạn thua!");
    }
}
