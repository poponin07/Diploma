using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefense
{
    public class ShootComponent : MonoBehaviour
    {
        [Header("Reloading Cooldowns")]
        [SerializeField] private bool m_CanShoot;
        [SerializeField] private float m_Cooldown;
        [SerializeField] private float m_CurCooldown;

        [Header("References")]
        [SerializeField] private Transform m_Target;
        [SerializeField] SphereCollider m_sphereCollider;
        
        [Header("Prefabs")]
        [SerializeField] private GameObject m_ProjectilePrefab;
        
        [Header("Minion parameters")] 
        [SerializeField] private float m_range;
        [SerializeField] private float m_damage;
        [SerializeField] private float m_attackSpeed;
        [SerializeField] private ElementType m_elementType;

        [SerializeField]private List<Transform> m_enemyTransforms = new List<Transform>();
        public ProjectilePool1 m_poolProjectile;
        
        public float Damage { get => m_damage; set => m_damage = value; }
        public float AttackSpeed { get => m_attackSpeed; set => m_attackSpeed = value; }
        public float Range { get => m_range; set => m_range = value; }
        public ElementType Elevental { get => m_elementType; set => m_elementType = value; }

        private void Start() 
         {
             m_CurCooldown = m_attackSpeed;
         }
         
         private void FixedUpdate() 
         {
             if (m_CurCooldown > 0 && !m_CanShoot)
             {
                 m_CurCooldown -= Time.deltaTime;
                 return;
             }
         
             isCanShoot();
             
             if (m_CanShoot)
             {
                 Shoot(); 
             }
         }

         public void SetNewParams(float damage, float attackSpeed, float range, ElementType elementType)
         {
             m_damage = damage;
             
             m_Cooldown = m_attackSpeed = attackSpeed;

             m_range = range;
             m_sphereCollider.radius = m_range;

             m_elementType = elementType;
         }
         
         private void isCanShoot()
         {
             if (m_CurCooldown <= 0 )
             {
                 m_CanShoot = true;
             }
         }
         //понимаю,что нужен пул,  но не успел
         private void Shoot()
         {
             if (m_enemyTransforms.Count > 0)
             {
                 m_Target = m_enemyTransforms.Last();
             }
             
             if (m_Target == null)
             {
                 return;
             }
             
             if (Vector3.Distance(gameObject.transform.position, m_Target.position) > m_range || m_Target.gameObject.activeSelf == false)
             {
                 m_enemyTransforms.Remove(m_Target);
                 m_Target = null;
                 return;
             }
             
             var bullet = m_poolProjectile.GetBullet();
             bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
             ProjectileComponent projectile = Instantiate(m_ProjectilePrefab, bullet.transform.position, Quaternion.identity).GetComponent<ProjectileComponent>();
             projectile.SetDamage(m_damage, m_elementType);
             m_CurCooldown = m_Cooldown;
             projectile.m_target = m_Target.transform;
             m_CanShoot = false; 
         }

         private void OnTriggerEnter(Collider other) 
         {
             if (other.tag == "Minion") 
             {
                 if (!m_enemyTransforms.Contains(other.transform))
                 {
                     m_enemyTransforms.Add(other.transform);
                 }
             }
         }

         private void  OnTriggerExit(Collider other) 
         {
             if (other.tag == "Minion") 
             {
                 if (m_enemyTransforms.Contains(other.transform))
                 {
                     m_enemyTransforms.Remove(other.transform);
                 }
             }
         }
        
     }
}