using UnityEngine;
using UnityEditor;

public static class TestErrorEmitter
{
    [MenuItem("Tools/Test/Emit Error")]
    public static void EmitError()
    {
        Debug.LogError("This is a test error emitted from the menu item!");
    }
}
