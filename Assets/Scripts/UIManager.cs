using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIButtonScriptHandler m_NextWaveButton;
        [SerializeField] private WaveManager m_waveManager;

        public void Start()
        {
            m_NextWaveButton.onClicked += OnStartWave;
        }

        public void OnStartWave()
        {
            m_waveManager.NextWave();
            m_NextWaveButton.Hide();
            
        }

        private void OnDestroy()
        {
            m_NextWaveButton.onClicked -= OnStartWave;
        }
    } 
