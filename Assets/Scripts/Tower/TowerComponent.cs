using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class TowerComponent : MonoBehaviour
{
   [SerializeField] private int m_price;
   
   [SerializeField] private float m_damage;
   [SerializeField] private float m_attackSpeed;
   [SerializeField] private float m_range;
   [SerializeField] private ElementType m_type;

   public bool isBuilt ;

   private ShootComponent m_shootComponent;

   public UIUpgradeWindow uiUpgradeWindow;
   public UpgradeTowerComponent upgradeTowerComponent;
   
   
   public float Damage { get => m_damage; set => m_damage = value; }
   public float AttackSpead { get => m_attackSpeed; set => m_attackSpeed = value; }
   public float Range { get => m_range; set => m_range = value; }
   public ElementType Elevental { get => m_type; set => m_type = value; }
   public int Price { get => m_price; }


   private void Start()
   {
      m_shootComponent = gameObject.GetComponent<ShootComponent>();
      SetTowerParams();
   }

   public ShootComponent GetShootParams()
   {
      ShootComponent shootComponent = new ShootComponent();

      shootComponent.Damage = m_damage;
      shootComponent.AttackSpeed = m_attackSpeed;
      shootComponent.Range = m_range;
      shootComponent.Elevental = m_type;
      
      return shootComponent;
   }
   public void SetTowerParams()
   {
      m_shootComponent.SetNewParams(m_damage, m_attackSpeed, m_range, m_type);
      
   }
   

}
