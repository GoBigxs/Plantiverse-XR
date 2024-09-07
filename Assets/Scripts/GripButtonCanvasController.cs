using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class GripButtonCanvasController : MonoBehaviour
{
    public GameObject canvasObject; // Assign your canvas object in the inspector
    private List<InputDevice> devices = new List<InputDevice>();
    private bool isGripPressed = false;
    public Transform controllerTransform; // Assign the controller's transform in the inspector
    public TextMeshProUGUI text;

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
                    PositionCanvas();
                    canvasObject.SetActive(true);
                }
                else if (!gripPressed)
                {
                    isGripPressed = false; // Grip has been released
                }
            }
        }
    }

    private void PositionCanvas()
    {
        if (controllerTransform != null)
        {
            canvasObject.transform.position = controllerTransform.position + controllerTransform.forward * 0.5f; // Adjust 0.5f to position it further or closer as needed
            canvasObject.transform.rotation = Quaternion.LookRotation(controllerTransform.forward);
        }
        PopulateCanvasWithText();
    }

    void PopulateCanvasWithText()
    {
        canvasObject.GetComponentInChildren<TextMeshProUGUI>().text = text.text;
    }
}
