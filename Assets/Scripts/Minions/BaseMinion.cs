using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class BaseMinion : MonoBehaviour
    {
        [SerializeField] public int m_health;
        [SerializeField] public int m_speed;
        [SerializeField] public ElementType m_type;

        public int Health
        {
            get { return m_health; }
            set
            {
                m_health = value;
                //UpdateUI();
            }
        }
        public int Speed
        {
            get { return m_speed; }
            set
            {
                m_speed = value;
            }
        }
    }
}