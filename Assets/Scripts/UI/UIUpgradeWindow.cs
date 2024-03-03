using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIUpgradeWindow : MonoBehaviour
{
   private TowerComponent m_towerComponent;
   public GameObject root;

   [SerializeField] private TextMeshProUGUI m_damagePriceText;
   [SerializeField] private TextMeshProUGUI m_attackSpeedPriceText;
   [SerializeField] private TextMeshProUGUI m_rangePriceText;
   
   [SerializeField] private TextMeshProUGUI m_damageParamsText;
   [SerializeField] private TextMeshProUGUI m_attackParamsPriceText;
   [SerializeField] private TextMeshProUGUI m_rangeParamsText;

   private void Start()
   {
      m_damagePriceText.text = m_attackSpeedPriceText.text = m_rangePriceText.text = "25";
   }

   public void Show()
   {
      root.SetActive(true);
   }


   public void SetNewPrice(int price)
   {
      m_damagePriceText.text = m_attackSpeedPriceText.text = m_rangePriceText.text = price.ToString();
   }
   
   public void SetParams(float damage, float attackSpeed, float range)
   {
      m_damageParamsText.text =  string.Format("{0:F0}", damage) + " + 25";
      m_attackParamsPriceText.text = string.Format("{0:F1}", attackSpeed) + " - 0.1";
      m_rangeParamsText.text = string.Format("{0:F1}", range) + " + 0.3";
   }
   
   public void Hide()
   {
      root.SetActive(false);
   }
   
   
}
