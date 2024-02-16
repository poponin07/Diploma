using System;
using UnityEngine;

namespace TowerDefense
{
    public class ProjectileComponent : MonoBehaviour
{
   [SerializeField] private float m_speed;
   [SerializeField] private ElementType m_type;
   [SerializeField] private float m_damage;
   
   [SerializeField] private Material m_commonMaterial;
   [SerializeField] private Material m_fireMaterial;
   [SerializeField] private Material m_iceMaterial;
   [SerializeField] private Material m_poisonMaterial;
  private MeshRenderer m_renderer;
    
   public Transform m_target;

   private void Start()
   {
       m_renderer = gameObject.GetComponent<MeshRenderer>();
       SetProjectileColor();
   }

   private void FixedUpdate()
   {
        Move();
    }

    public void SetDamage(float damage, ElementType elementType)
    {
        m_damage = damage;
        m_type = elementType;
    }
    
    private void Move()
    {
        if (m_target == null || !m_target.gameObject.activeSelf)
        {
            Destroy(gameObject);
        }
        transform.LookAt(m_target);
        gameObject.transform.Translate(Vector3.forward* m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Minion")
        {
            BaseMinion minion = other.GetComponent<BaseMinion>();
            minion.GetDamage(m_damage, m_type);
            
            Destroy(gameObject);
        }
    }

   private void SetProjectileColor()
    {
        switch (m_type)
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
}