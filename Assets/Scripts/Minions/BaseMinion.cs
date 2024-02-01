using Minions;
using UnityEngine.Events;
using UnityEngine;

namespace TowerDefense
{
    public class BaseMinion : MonoBehaviour, IGetDamage, IBaseMinion
    {
      /*  public float health { get => m_health; set => m_health = value; }
        public float speed { get => m_speed; set => m_health = value;}
        public float damage { get => m_damage; set => m_damage = value;}
        public ElementType element { get; set; }
        public MinionType type { get => m_element;
            set => m_element = value;
        }*/
        
        [SerializeField] private float m_health;
        [SerializeField] private float m_speed;
        [SerializeField] private float m_damage;
        [SerializeField] private ElementType m_element;
        [SerializeField] private MinionType m_type;
        public bool m_iselemental;
        private UnityAction m_DieAction;
      
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
        
          
        public void Initialization(WaveManager waveManager)
        {
           waveManager.GetMinionData(this);
        }
        
        public void GetDamage(float damage)
        {
            m_health -= m_damage;
            
            OnDie();
            
            if (m_health <= 0)
            {
                OnDie();
            }
        }

        public void OnDie()
        {
            Destroy(gameObject);
        }
    }
}