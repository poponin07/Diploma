using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    public class BaseComponent : MonoBehaviour
    {
        [SerializeField] private int m_health;
        [SerializeField] private UIBaseComponent m_uiBaseComponent;

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
                m_health--;
                if (m_health <= 0)
                {
                    m_health = 0;
                }
                m_uiBaseComponent.SetUIBase(m_health);
            }
            
        }
}
}