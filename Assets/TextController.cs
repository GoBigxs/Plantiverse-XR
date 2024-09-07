using UnityEngine;
using TMPro; // Include this namespace to work with TextMeshPro

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI textElement; // Assign this in the inspector
    public RectTransform textRectTransform; // Assign this in the inspector

    void Start()
    {
        UpdateText("Initial Text");
    }

    public void UpdateText(string newText)
    {
        if (textElement != null)
        {
            textElement.text = newText; // Update the text content
            UpdateRectTransform(); // Update RectTransform based on the new text
        }
    }

    void UpdateRectTransform()
    {
        // Adjust the size of the RectTransform based on the text dimensions
        // This might include setting it to the preferred values or using Layout Rebuilder
        textRectTransform.sizeDelta = new Vector2(textRectTransform.sizeDelta.x, textRectTransform.sizeDelta.y);
        // You may want to add logic to adjust width similarly if needed
    }
}
