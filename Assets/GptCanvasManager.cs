using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GptCanvasManager : MonoBehaviour
{
    public GameObject canvas; // Assign the canvas object in the inspector
    public UnityEvent onAButtonPressed;  // Assign actions in the editor for button press
    public UnityEvent onAButtonReleased; // Assign actions in the editor for button release

    private bool isVisible = true; // Initial state of the canvas
    private bool aButtonPressed = false; // Tracking the state of the A button
    private float cooldown = 1.0f; // Cooldown period in seconds
    private float lastToggleTime = 0; // Time since last toggle

    void Update()
    {
        InputDevice rightHandController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Toggle Canvas with B button
        if (rightHandController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool bPressed) && bPressed)
        {
            if (Time.time > lastToggleTime + cooldown)
            {
                ToggleVisibility();
                lastToggleTime = Time.time; // Reset the last toggle time
            }
        }

        // Perform actions assigned to A button
        if (rightHandController.TryGetFeatureValue(CommonUsages.primaryButton, out bool aPressed))
        {
            if (aPressed && !aButtonPressed)
            {
                if (Time.time > lastToggleTime + cooldown)
                {
                    onAButtonPressed.Invoke();
                    aButtonPressed = true;
                    lastToggleTime = Time.time; // Reset the last toggle time
                }
            }
            else if (!aPressed && aButtonPressed)
            {
                onAButtonReleased.Invoke();
                aButtonPressed = false;
            }
        }
    }

    void ToggleVisibility()
    {
        isVisible = !isVisible;
        canvas.SetActive(isVisible);
    }
}
