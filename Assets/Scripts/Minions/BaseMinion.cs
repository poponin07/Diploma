using System;
using Minions;
using TowerDefense.DynamicPool;
using UnityEngine;
using Random = UnityEngine.Random;


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

        [SerializeField] private Material m_commonMaterial;
        [SerializeField] private Material m_fireMaterial;
        [SerializeField] private Material m_iceMaterial;
        [SerializeField] private Material m_poisonMaterial;
        
        public bool m_isElemental;
        
        public MinionUI m_minionUI;

        public Action<BaseMinion> onDied;
        public Action<BaseMinion> onSpawn;
        public Action<int> onScore;

        
        public float Health { get => m_health; set => m_health = value; }
        public int Score { get => m_score; set => m_score = value; }
        public float Speed { get => m_speed; set => m_speed = value; }
        public float Damage { get => m_damage; set => m_damage = value; }
        public MinionType Type { get => m_type; set => m_type = value; }
        public ElementType Element { get => m_element; set => m_element = value; }

        [SerializeField] private MeshRenderer m_renderer;

        
        private void Start()
        {
            SetRandomElement();
            m_minionUI.SetHealth(m_health, Element);
        }

        //установка рандомной стихии
        private void SetRandomElement()
        {
            if (m_isElemental)
            {
                int randomIndex = Random.Range(0, 4);
                Element = (ElementType)randomIndex;

                switch (m_element)
                {
                    case ElementType.None:
                        m_renderer.material = m_commonMaterial;
                        break;
                    
                    case ElementType.Fire:
                        m_renderer.material = m_fireMaterial;
                        break;
                    
                    case ElementType.Ice:
                        m_renderer.material = m_iceMaterial;
                        break;
                    
                    case ElementType.Poison:
                        m_renderer.material = m_poisonMaterial;
                        break;
                }
            }
        }

        public void GetDamage(float damage, ElementType projectileType)
        {
            float multiplierDamage = CalculationElementalDamage.CalculationDamage(Element, projectileType);
            Health -= damage * multiplierDamage;
            m_minionUI.RefreshHealth(Health);
            
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
            transform.position = new Vector3(50, 50, 50);
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