using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called once
    //  before the first execution of Update after the MonoBehaviour is created
    public Image selectedPlanePreview;
    public Sprite[] planePreviews;
    public GameObject characterSelectedPanel;
    private int currentPlaneIndex;

    public void Start()
    {
        currentPlaneIndex = PlayerPrefs.GetInt("SelectedPlaneIndex", 0);
        if (planePreviews == null || planePreviews.Length == 0)
        {
            Debug.LogError("Chưa gán giá trị vào PlanePreviews.");
            return;
        }

        currentPlaneIndex = Mathf.Clamp(currentPlaneIndex, 0, planePreviews.Length - 1);
        UpdatePlanePreviews();

    }

    public void PreviousPlane()
    {
        currentPlaneIndex = (currentPlaneIndex - 1 + planePreviews.Length) % planePreviews.Length;
        UpdatePlanePreviews();
    }

    public void NextPlane()
    {
        currentPlaneIndex = (currentPlaneIndex + 1) % planePreviews.Length;
        UpdatePlanePreviews();
    }



    public void UpdatePlanePreviews()
    {
        selectedPlanePreview.sprite = planePreviews[currentPlaneIndex];
    }

    public void OpenCharacterSelection()
    {
        characterSelectedPanel.SetActive(true);
        UpdatePlanePreviews();
    }

    public void SelectPlane()
    {
        PlayerPrefs.SetInt("SelectedPlaneIndex", currentPlaneIndex);
        PlayerPrefs.Save();
        characterSelectedPanel.SetActive(false);
    }

    public void JoinGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
