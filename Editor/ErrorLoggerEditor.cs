using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public static class ErrorLoggerEditor
{
    private static readonly string errorFilePath = "Assets/WindsurfError.txt";

    static ErrorLoggerEditor()
    {
        AssemblyReloadEvents.afterAssemblyReload += OnAfterAssemblyReload;
    }

    private static void OnAfterAssemblyReload()
    {
        Application.logMessageReceived += HandleLog;
    }

    private static void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            File.WriteAllText(errorFilePath, logString);
            Application.logMessageReceived -= HandleLog;
        }
    }
}
