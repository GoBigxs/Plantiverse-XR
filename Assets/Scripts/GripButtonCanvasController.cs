using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class GripButtonCanvasController : MonoBehaviour
{
    public GameObject canvasPrefab; // Assign your canvas prefab in the inspector
    private List<InputDevice> devices = new List<InputDevice>();
    private bool isGripPressed = false;
    public Transform controllerTransform; // Assign the controller's transform in the inspector
    public TextMeshProUGUI textToCopy;

    void Update()
    {
        devices.Clear();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, devices);
        CheckGripPress();
    }

    private void CheckGripPress()
    {
        foreach (var device in devices)
        {
            if (device.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed))
            {
                if (gripPressed && !isGripPressed)
                {
                    isGripPressed = true; // Grip is currently being pressed
                    InstantiateAndPositionCanvas();
                }
                else if (!gripPressed)
                {
                    isGripPressed = false; // Grip has been released
                }
            }
        }
    }

    private void InstantiateAndPositionCanvas()
    {
        if (controllerTransform != null)
        {
            // Instantiate a new canvas object
            GameObject newCanvas = Instantiate(canvasPrefab, controllerTransform.position + controllerTransform.forward * 0.5f, Quaternion.LookRotation(controllerTransform.forward));
            newCanvas.SetActive(true);
            TextMeshProUGUI tmp = newCanvas.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null)
                tmp.text = textToCopy.text;  // Set the text dynamically
            tmp.enableWordWrapping = true;
        }
        else
        {
            Debug.LogError("Controller transform is null");
        }
    }
}
