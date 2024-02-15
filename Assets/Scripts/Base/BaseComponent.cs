using System;
using System.Collections;
using System.Collections.Generic;
using Score;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace TowerDefense
{
    public class BaseComponent : MonoBehaviour
    {
        [SerializeField] private int m_health;
        [SerializeField] private UIBaseComponent m_uiBaseComponent;
        [SerializeField] private ScoreComponent m_scoreComponent;
        [SerializeField]private GameObject m_gameOverPanel;

        private void Start()
        {
            m_uiBaseComponent.SetUIBase(m_health);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Minion")
            {
                BaseMinion minion = other.gameObject.GetComponent<BaseMinion>();
                minion.Despawn(true);
                m_health -= 99;
                m_health --;
                
                if (m_health <= 0)
                {
                    m_health = 0;
                    m_gameOverPanel.SetActive(true);
                    SaveComponent.SaveGame(m_scoreComponent.GetBestScore());
                }
                m_uiBaseComponent.SetUIBase(m_health);
            }
            
        }
}
}