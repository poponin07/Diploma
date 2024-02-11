using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Button m_startButton;
    
    [SerializeField] private TextMeshProUGUI m_bestScoreText;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
