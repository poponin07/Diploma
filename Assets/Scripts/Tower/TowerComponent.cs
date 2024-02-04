using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class TowerComponent : MonoBehaviour
{
   [SerializeField] private int m_price;
   private int m_level;
   private float m_damage;
   private float m_attackSpeed;
   private float m_range;
   private ElementType m_type;
   
   public int Price { get => m_price;
   }

   public void UpDamage()
   {
      
   }
   
   public void UpRange()
   {
      
   }
   
   public void AttackSpeed()
   {
      
   }
   
   public void SetElemental()
   {
      
   }
}
