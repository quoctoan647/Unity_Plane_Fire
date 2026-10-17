using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Đây là phần của Singleton
    public static GameManager _i;
    public bool isPaused;
    public void Awake()
    {
        _i =  this;
    }
    public void BeginGame()
    {
        Debug.Log("GameManager begin");
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PauseGame();
            Debug.Log(isPaused);
        }
        
    }


}
