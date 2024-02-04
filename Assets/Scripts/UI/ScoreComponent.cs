using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

namespace Score
{

    public class ScoreComponent : MonoBehaviour
    {
        private int m_score;
        private int m_bestScore;

        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private TextMeshProUGUI m_bestScoreText;

        public void UpdateScore(int score)
        { 
            m_score += score;
            m_scoreText.text = "Score: " + m_score;
            
            if (m_score > m_bestScore)
            {
                m_bestScore = m_score;
                m_bestScoreText.text = "Best score: " + m_bestScore;
            }
        }
    }
}