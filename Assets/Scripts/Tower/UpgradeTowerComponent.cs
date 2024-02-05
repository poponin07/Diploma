using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class UpgradeTowerComponent : MonoBehaviour
{
    public TowerComponent m_TowerComponent;
    
    private int m_damageGradeIndex = 0;
    private int m_attackSpeedGradIndex = 0;
    private int m_rangeGradeIndex = 0;
    private int m_priceIndex = 0;

    [SerializeField] private PlayerData m_playerData;
    
    [SerializeField] private float m_damageGradeValue = 25;
    [SerializeField] private float m_attackSpeedGradValue = 0.2f;
    [SerializeField] private float m_rangeGradeValue = 0.5f;
    
    [SerializeField] private int m_priceGradeValue = 25;
    [SerializeField] private int m_startPrice = 25;
    [SerializeField] private int m_priceIndexMax = 15;
    

    public void UpgradeDamage()
    {
        
        if (m_damageGradeIndex >= 5 && !m_playerData.CheckCoins(m_priceGradeValue))
        {
            return;
        }

        m_TowerComponent.Damage += m_damageGradeValue;
        m_damageGradeIndex++;
        m_priceIndex++;
    }
    
    public void UpgradeAttackSpeed()
    {
        if (m_attackSpeedGradIndex >= 5 && !m_playerData.CheckCoins(m_priceGradeValue))
        {
            return;
        }

        m_TowerComponent.Damage += m_attackSpeedGradValue;
        m_attackSpeedGradIndex++;
        m_priceIndex++;
    }
    
    public void UpgradeRange()
    {
        if (m_rangeGradeIndex >= 5 && !m_playerData.CheckCoins(m_priceGradeValue))
        {
            return;
        }

        m_TowerComponent.Damage += m_rangeGradeValue;
        m_rangeGradeIndex++;
        m_priceIndex++;
    }

}