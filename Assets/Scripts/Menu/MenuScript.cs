using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
