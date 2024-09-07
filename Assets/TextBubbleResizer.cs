using UnityEngine;
using TMPro;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class TextBubbleResizer : MonoBehaviour
{
    public RectTransform canvasRectTransform;  // Reference to the RectTransform of the canvas
    public TextMeshProUGUI textMeshPro;        // Reference to the TextMeshPro component

    public Vector2 padding = new Vector2(10, 10);  // Padding to add around the text

    void Update()
    {
        ResizeCanvasToFitText();
    }

    void ResizeCanvasToFitText()
    {
        if (textMeshPro == null) return;

        // Update the size of the text mesh
        textMeshPro.ForceMeshUpdate();

        // Calculate the size needed for the text with padding
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 newSize = new Vector2(textSize.x + padding.x, textSize.y + padding.y);

        // Apply the new size to the canvas
        canvasRectTransform.sizeDelta = newSize;
    }
}