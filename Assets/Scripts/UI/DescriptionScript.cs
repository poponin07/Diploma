using UnityEngine;

public class DescriptionScript : MonoBehaviour
{
    [SerializeField] private GameObject m_root;

    public void Show()
    {
        m_root.SetActive(true);
    }
   
   public void Hide()
   {
       m_root.SetActive(false);
   }
}
