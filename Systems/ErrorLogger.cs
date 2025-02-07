using Unity.Entities;
using UnityEngine;

public partial class ErrorLogger : SystemBase
{
    protected override void OnCreate()
    {
        // Application.logMessageReceived += HandleLog;
        EntityManager.CreateSingleton<LogListenerSetup>();
        Debug.Log("Error logger initialized");
    }

    protected override void OnUpdate()
    {
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            Debug.LogWarning($"Caught Error: {logString}\nStack Trace: {stackTrace}");
        }

        //Split the stack trace up into individual lines
        string[] stackTraceLines = stackTrace.Split('\n');

        //Log each line of the stack trace that 
        foreach (string line in stackTraceLines)
        {
            if (line.Contains("Unity.Entities"))
            {
                Debug.LogWarning($"Caught Error: {logString}\nStack Trace: {stackTrace}");
                break;
            }
        }
    }

    protected override void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }
}
