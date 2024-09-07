using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GptCanvasManager : MonoBehaviour
{
    public GameObject canvas; // Assign the canvas object in the inspector

    private bool isVisible = true; // Initial state of the canvas

    // Update is called once per frame
    void Update()
    {
        // Get the right-hand device
        InputDevice rightHandController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Check if B button (secondary button) is pressed
        if (rightHandController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool pressed) && pressed)
        {
            // Delay next toggle to avoid multiple toggles per press
            if (Time.frameCount % 10 == 0)  // Checks every 10 frames
            {
                ToggleVisibility();
            }
        }
    }

    void ToggleVisibility()
    {
        // Toggle the visibility of the canvas
        isVisible = !isVisible;
        canvas.SetActive(isVisible);
    }
}
