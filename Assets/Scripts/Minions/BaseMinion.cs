using System;
using Minions;
using TowerDefense.DynamicPool;
using UnityEngine.Events;
using UnityEngine;

namespace TowerDefense
{
    public class BaseMinion : MonoBehaviour, IGetDamage, IBaseMinion, IPooledObject
    {
        [SerializeField] private float m_health;
        [SerializeField] private float m_speed;
        [SerializeField] private float m_damage;
        [SerializeField] private ElementType m_element;
        [SerializeField] private MinionType m_type;
        public bool m_isElemental;
        
        public Action<BaseMinion> onDied;
        public Action<BaseMinion> onSpawn;

      
        public float Health
        {
            get => m_health;
            set => m_health = value;
            //UpdateUI();
        }
        public float Speed
        {
            get => m_speed;
            set => m_speed = value;
        }
        public float Damage
        {
            get => m_damage;
            set => m_damage = value;
        }
        public MinionType Type
        {
            get => m_type;
            set => m_type = value;
        }
        public ElementType Element
        {
            get => m_element;
            set => m_element = value;
        }

        public void GetDamage(float damage)
        {
            m_health -= m_damage;
            
            Despawn();
            
            if (m_health <= 0)
            {
                Despawn();
            }
        }

        public void Despawn()
        {
            onDied.Invoke(this);
        }

        public void Spawn()
        {
            onSpawn.Invoke(this);
        }

        public void OnGetFromPool()
        {
            gameObject.SetActive(false);
        }

        public void OnRelease()
        {
            gameObject.SetActive(false);
        }
        
        
    }
}