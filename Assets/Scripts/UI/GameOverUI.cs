using Score;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_bestScoreText;
    [SerializeField] private ScoreComponent m_scoreComponent;

    private void Awake()
    {
        m_scoreText.text = "Score: " + m_scoreComponent.GetScore().ToString();
        m_bestScoreText.text = "Best score: " + m_scoreComponent.GetBestScore().ToString();
    }
}
