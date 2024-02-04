using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoinComponent : MonoBehaviour
{ 
    private int m_score;

    [SerializeField] private TextMeshProUGUI m_coinText;

    public void UpdateUICoin(int coins)
    {
        m_coinText.text = coins.ToString();
    }
}
