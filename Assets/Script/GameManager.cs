using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Đây là phần của Singleton
    public static GameManager _i;
    public void Awake()
    {
        _i =  this;
    }
    public void BeginGame()
    {
        Debug.Log("GameManager begin");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
