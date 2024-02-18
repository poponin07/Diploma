using TowerDefense;
using UnityEngine;

public class UpgradeTowerComponent : MonoBehaviour
{
    public TowerComponent m_TowerComponent;
    public UIUpgradeWindow uiUpgradeTowerComponent;
    
    private int m_damageGradeIndex = 0;
    private int m_attackSpeedGradIndex = 0;
    private int m_rangeGradeIndex = 0;
    private int m_priceIndex = 0;

    public PlayerData m_playerData;
    
    [SerializeField] private float m_damageGradeValue = 25;
    [SerializeField] private float m_attackSpeedGradValue = 0.1f;
    [SerializeField] private float m_rangeGradeValue = 0.3f;
    
    [SerializeField] private int m_priceGradeValue = 25;
    [SerializeField] private int m_startPrice = 25;
    [SerializeField] private int m_priceIndexMax = 5;


    private void Start()
    {
        m_TowerComponent = gameObject.GetComponent<TowerComponent>();
        uiUpgradeTowerComponent = m_TowerComponent.uiUpgradeWindow;
        uiUpgradeTowerComponent.SetParams(m_TowerComponent.Damage, m_TowerComponent.AttackSpead, m_TowerComponent.Range);
    }

    public void UpgradeDamage()
    {
        if (m_damageGradeIndex >= m_priceIndexMax || !m_playerData.CheckCoins(m_priceGradeValue))
        {
            return;
        }

        m_TowerComponent.Damage += m_damageGradeValue;
        m_priceGradeValue = m_startPrice + (m_startPrice * m_priceIndex);
        uiUpgradeTowerComponent = m_TowerComponent.uiUpgradeWindow;
        uiUpgradeTowerComponent.SetNewPrice(m_priceGradeValue);
        uiUpgradeTowerComponent.SetParams(m_TowerComponent.Damage, m_TowerComponent.AttackSpead, m_TowerComponent.Range);
        m_TowerComponent.SetTowerParams();
        m_damageGradeIndex++;
        m_priceIndex++;
    }
    
    public void UpgradeAttackSpeed()
    {
        if (m_attackSpeedGradIndex >= m_priceIndexMax || !m_playerData.CheckCoins(m_priceGradeValue))
        {
            return;
        }

        m_TowerComponent.AttackSpead -= m_attackSpeedGradValue;
        m_priceGradeValue = m_startPrice + (m_startPrice * m_priceIndex);
        uiUpgradeTowerComponent = m_TowerComponent.uiUpgradeWindow;
        uiUpgradeTowerComponent.SetNewPrice(m_priceGradeValue);
        uiUpgradeTowerComponent.SetParams(m_TowerComponent.Damage, m_TowerComponent.AttackSpead, m_TowerComponent.Range);
        m_TowerComponent.SetTowerParams();
        m_attackSpeedGradIndex++;
        m_priceIndex++;
    }
    
    public void UpgradeRange()
    {
        if (m_rangeGradeIndex >= m_priceIndexMax || !m_playerData.CheckCoins(m_priceGradeValue))
        {
            return;
        }

        m_TowerComponent.Range += m_rangeGradeValue;
        m_priceGradeValue = m_startPrice + (m_startPrice * m_priceIndex);
        uiUpgradeTowerComponent = m_TowerComponent.uiUpgradeWindow;
        uiUpgradeTowerComponent.SetParams(m_TowerComponent.Damage, m_TowerComponent.AttackSpead, m_TowerComponent.Range);
        uiUpgradeTowerComponent.SetNewPrice(m_priceGradeValue);
        m_TowerComponent.SetTowerParams();
        m_rangeGradeIndex++;
        m_priceIndex++;
    }

    public void RefreshUI()
    {
        uiUpgradeTowerComponent.SetNewPrice(m_priceGradeValue);
    }

}
