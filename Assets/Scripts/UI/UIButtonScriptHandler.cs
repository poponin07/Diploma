using System;
using UnityEngine;

public class UIButtonScriptHandler : MonoBehaviour
{
    public Action onClicked;
    
    [SerializeField] private GameObject root;

    public void ButtonClicked()
    {
        onClicked?.Invoke();
    }

    public void Show()
    {
        root.SetActive(true);
    }
    
    public void Hide()
    {
        root.SetActive(false);
    }

}