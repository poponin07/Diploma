using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BaseAbility : MonoBehaviour
{
    [SerializeField] protected float m_coolDown;
    private bool abilityAvailable => m_enabled; 
    public float localCooldown => m_coolDown;
    private float m_cooldownTimeStamp;
    private bool m_enabled;

    private TextMeshProUGUI m_textMeshProUGUI;

    private float m_currentTime;
    private Button m_button;

    public void StartTimer(TextMeshProUGUI textMeshProUGUI, Button button)
    {
        m_textMeshProUGUI = textMeshProUGUI;
        m_textMeshProUGUI.enabled = true;
        m_button = button;
        m_enabled = true;
        m_button.interactable = false;
        isBuild();
        m_cooldownTimeStamp = m_coolDown;
    }

    private void Update()
    {
        if (m_enabled)
        {
            m_cooldownTimeStamp -= Time.deltaTime;

            if (m_cooldownTimeStamp > 0)
            {
                m_textMeshProUGUI.text = Mathf.Round(m_cooldownTimeStamp).ToString();
            }
            
            else
            {
                m_button.interactable = true;
                m_textMeshProUGUI.enabled = false;
                m_enabled = false; 
                Destroy(gameObject);
            }
        }
    }

    protected virtual void isBuild()
    {
    }
}
