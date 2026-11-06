using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void JoinGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
