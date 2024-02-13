using UnityEngine;

namespace TowerDefense
{
    public class UpgradeScript : MonoBehaviour
    {
       public UpgradeTowerComponent m_selectedUpgrade;
        
        public void UpDamage()
        {
            m_selectedUpgrade.UpgradeDamage();
        }
   
        public void UpRange()
        {
            m_selectedUpgrade.UpgradeRange();
        }
   
        public void UpAttackSpeed()
        {
            m_selectedUpgrade.UpgradeAttackSpeed();
        }
    }
}