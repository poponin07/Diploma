using UnityEngine;
using TMPro;

namespace TowerDefense
{

    public class UIBaseComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_healthText;

        public void SetUIBase(int health)
        {
            m_healthText.text = health.ToString();
        }
        
    }
}