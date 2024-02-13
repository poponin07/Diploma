using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIUpgradeWindow : MonoBehaviour
{
   private TowerComponent m_towerComponent;
   public GameObject root;
   public Button damageButton;
   public Button attackSpeedButton;
   public Button rangeSpeedButton;
   
   [SerializeField] private TextMeshProUGUI m_damagePriceText;
   [SerializeField] private TextMeshProUGUI m_attackSpeedPriceText;
   [SerializeField] private TextMeshProUGUI m_rangePriceText;

   private void Start()
   {
      m_damagePriceText.text = m_attackSpeedPriceText.text = m_rangePriceText.text = "25";
   }

   public void Show()
   {
      root.SetActive(true);
   }
   
   
   public void SetSetNewPrice(int price)
   {
      m_damagePriceText.text = m_attackSpeedPriceText.text = m_rangePriceText.text = price.ToString();
   
   }
   
   public void Hide()
   {
      root.SetActive(false);
   }
   
   
}
