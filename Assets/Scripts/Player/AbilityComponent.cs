using System.Collections;
using System.Collections.Generic;
using Score;
using TowerDefense;
using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    [SerializeField] private BaseComponent m_baseComponent;
    [SerializeField] private PlayerData m_playerData;
    [SerializeField] private ScoreComponent m_scoreComponent;

    public void Heal()
    {
        if (m_playerData.CheckCoins(500))
        {
            m_baseComponent.AddHeath(5);
        }
        
    }
    
    public void AddScore()
    {
        if (m_playerData.CheckCoins(200))
        {
            m_scoreComponent.UpdateScore(100);
        }
    }
}
