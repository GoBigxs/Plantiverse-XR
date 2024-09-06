using UnityEngine;
using TMPro;

public class DebugLogger : MonoBehaviour
{
    // Reference to the TextMeshPro text object in the canvas
    public TextMeshProUGUI debugText;

    // String to store all logs
    private string logMessages = "";

    private void OnEnable()
    {
        // Subscribe to the log message received callback
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        // Unsubscribe when the object is disabled
        Application.logMessageReceived -= HandleLog;
    }

    // Callback function to handle log messages
    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Add the log message to the stored log string
        logMessages += logString + "\n";

        // Optionally include stack trace for error logs
        if (type == LogType.Error || type == LogType.Exception)
        {
            logMessages += stackTrace + "\n";
        }

        // Display the log messages in the TextMeshPro text object
        if (debugText != null)
        {
            debugText.text = logMessages;
        }
    }
}