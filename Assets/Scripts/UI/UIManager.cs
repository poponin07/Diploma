using System;
using System.Collections;
using System.Collections.Generic;
using Score;
using TowerDefense;
using UnityEngine;
using UnityEngine.UI;
using Waves;

public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIButtonScriptHandler m_NextWaveButton;
        [SerializeField] private WaveManager m_waveManager;
        public ScoreComponent m_scoreComponent;

        public void Start()
        {
            m_NextWaveButton.onClicked += OnStartWave;
            m_scoreComponent = GetComponent<ScoreComponent>();
        }

        public void EnableNextWaveButton()
        {
            m_NextWaveButton.Show();
        }

        public void OnStartWave()
        {
            m_waveManager.NextWave();
            m_NextWaveButton.Hide();
        }

        public void SetScore(int score)
        {
            m_scoreComponent.UpdateScore(score);
        }
        
        private void OnDestroy()
        {
            m_NextWaveButton.onClicked -= OnStartWave;
        }
    } 
