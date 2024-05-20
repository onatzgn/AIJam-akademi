using UnityEngine;
using UnityEngine.UI;

public class DetailsToggle : MonoBehaviour
{
    public GameObject details; 
    public Button toggleButton; 
    public Button closeButton; 

    void Start()
    {
        if (details != null)
        {
            details.SetActive(false);
        }

      
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleDetails);
        }

      
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseDetails);
        }
    }

    void ToggleDetails()
    {
        if (details != null)
        {
           
            details.SetActive(!details.activeSelf);
        }
    }

    void CloseDetails()
    {
        if (details != null)
        {
            
            details.SetActive(false);
        }
    }
}