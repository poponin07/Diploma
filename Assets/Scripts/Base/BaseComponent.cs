using Score;
using UnityEngine;

namespace TowerDefense
{
    public class BaseComponent : MonoBehaviour
    {
        [SerializeField] private int m_health;
        
        [Header("UI")]
        [SerializeField] private UIBaseComponent m_uiBaseComponent;
        [SerializeField] private ScoreComponent m_scoreComponent;
        [SerializeField] private GameObject m_gameOverPanel;
        private string m_MinionTag = "Minion";

        private void Start()
        {
            m_uiBaseComponent.SetUIBase(m_health);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals(m_MinionTag))
            {
                BaseMinion minion = other.gameObject.GetComponent<BaseMinion>();
                minion.Despawn(true);
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

        public void AddHeath(int health)
        {
            m_health += health;
            m_uiBaseComponent.SetUIBase(m_health);
        }
}
}