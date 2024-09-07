using UnityEngine;
using TMPro; // Include this namespace to work with TextMeshPro

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI textElement; // Assign this in the inspector

    void Start()
    {
        UpdateText("Initial Text");
    }

    public void UpdateText(string newText)
    {
        if(textElement != null)
            textElement.text = newText; // Update the text content
    }
    
}
