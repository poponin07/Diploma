using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class BaseMinion : MonoBehaviour
    {
        [SerializeField] private float m_health;
        [SerializeField] private float m_speed;
        [SerializeField] private float m_damage;
        [SerializeField] private ElementType m_element;
        [SerializeField] private MinionType m_type;
        public bool m_iselemental;

        
        public float Health
        {
            get { return m_health; }
            set
            {
                m_health = value;
                //UpdateUI();
            }
        }
        public float Speed
        {
            get { return m_speed; }
            set
            {
                m_speed = value;
            }
        }
        public float Damage
        {
            get { return m_damage; }
            set
            {
                m_damage = value;
            }
        }
        public MinionType Type
        {
            get { return m_type; }
            set
            {
                m_type = value;
            }
        }
        
        public ElementType Element
        {
            get { return m_element; }
            set
            {
                m_element = value;
            }
        }
    }
}