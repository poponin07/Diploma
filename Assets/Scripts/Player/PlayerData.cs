using System;
using System.Collections;
using System.Collections.Generic;
using Score;
using UnityEngine;
using Waves;

namespace TowerDefense
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private WaveManager m_wavemanager;
        [SerializeField] private ScoreComponent m_scoreComponent;
        [SerializeField] private UICoinComponent m_coinComponent;
        private int m_score;
        private int m_coin;


        private void Start()
        {
            m_coin = 200;
            m_coinComponent.UpdateUICoin(m_coin);
        }

        public void SetScoreAndCoin(int score)
        {
            m_score += score;
            m_coin += score;
            m_scoreComponent.UpdateScore(score);
            m_coinComponent.UpdateUICoin(m_coin);
        }

        public bool CheckCoins(int price)
        {
            int bufCoins = m_coin;
            bufCoins -= price;
            if (bufCoins >= 0)
            {
                m_coin = bufCoins;
                m_coinComponent.UpdateUICoin(m_coin);
                return true;
            }
            return false;
        }
    }
}