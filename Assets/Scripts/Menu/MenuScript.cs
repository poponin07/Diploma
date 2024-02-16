using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_bestScoreText;

    private void Start()
    {
        m_bestScoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
