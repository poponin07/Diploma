using UnityEngine;

public class BuildPanelScriptAnimation : MonoBehaviour
{
    private bool isShow;
    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void Show()
    {
        m_animator.Play("Close");
        isShow = m_animator.GetBool("isShow");

        if (isShow)
        {
            m_animator.SetBool("isShow", isShow = false);
        }
      else
        {
            m_animator.SetBool("isShow", isShow = true);
        }
        
        
      
    }
}
