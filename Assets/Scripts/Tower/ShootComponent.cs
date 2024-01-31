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
        
        [Range(0, 100)] 
        [SerializeField] private float m_range;

        private List<Transform> m_enemyTransforms = new List<Transform>();

        private void Start() 
         {
             m_sphereCollider.radius = m_range;
             m_CurCooldown = 1;
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
         private void isCanShoot()
         {
             if (m_CurCooldown <= 0 )
             {
                 m_CanShoot = true;
             }
         }
         
         private void Shoot()
         {
             if (m_enemyTransforms.Count < 1)
             {
                 return;
             }
             
             m_Target = m_enemyTransforms.Last();
             if (m_Target == null)
             {
                 return;
             }
             var spawnTransform = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
             ProjectileComponent projectile = Instantiate(m_ProjectilePrefab, spawnTransform, Quaternion.identity).GetComponent<ProjectileComponent>();
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