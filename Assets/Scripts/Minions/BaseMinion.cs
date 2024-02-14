using System;
using System.Security.Cryptography;
using Minions;
using TowerDefense.DynamicPool;
using UnityEngine.Events;
using UnityEngine;
using Random = System.Random;

namespace TowerDefense
{
    public class BaseMinion : MonoBehaviour, IBaseMinion, IPooledObject
    {
        [SerializeField] private float m_health;
        [SerializeField] private float m_speed;
        [SerializeField] private float m_damage;
        [SerializeField] private int m_score;
        [SerializeField] private ElementType m_element;
        [SerializeField] private MinionType m_type;
        //[SerializeField] private SpawnComponent _spawnComponent;
        public bool m_isElemental;
        
        
        public Action<BaseMinion> onDied;
        public Action<BaseMinion> onSpawn;
        public Action<int> onScore;

        
        public float Health { get => m_health; set => m_health = value; }
        public int Score { get => m_score; set => m_score = value; }
        public float Speed { get => m_speed; set => m_speed = value; }
        public float Damage { get => m_damage; set => m_damage = value; }
        public MinionType Type { get => m_type; set => m_type = value; }
        public ElementType Element { get => m_element; set => m_element = value; }


        //RANDOM
        private void Start()
        {
            
        }

        public void GetDamage(float damage, ElementType projectileType)
        {
            float multiplierDamage = CalculationElementalDamage.CalculationDamage(Element, projectileType);
            
            Health -= damage * multiplierDamage;
            
            if (Health <= 0)
            {
                Despawn(false);
            }
        }

        public void Despawn(bool isBase)
        {
            if (!isBase)
            {
                onDied?.Invoke(this);
                onScore?.Invoke(Score); 
            }
            onDied.Invoke(this);
        }

        public void Spawn()
        {
            onSpawn?.Invoke(this);
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