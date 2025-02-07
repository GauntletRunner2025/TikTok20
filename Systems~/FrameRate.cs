using Unity.Entities;
using UnityEngine;

public partial class FrameRate : SystemBase
{
    protected override void OnCreate()
    {
        Application.targetFrameRate = 20;
        Debug.Log($"Set target frame rate to {Application.targetFrameRate} FPS");
    }

    protected override void OnUpdate()
    {
        // Nothing to do during update
    }
}
