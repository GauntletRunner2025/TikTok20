using Unity.Entities;
using UnityEngine;
using UnityEngine.Video;

public partial class VideoControl : SystemBase
{
    protected override void OnCreate()
    {
        // Get the main camera
        var mainCamera = Camera.main;
        if (mainCamera == null)
        {
            throw new System.Exception("No main camera found in scene");
        }

        // Find the existing VideoPlayer on the camera
        var videoPlayer = mainCamera.GetComponentInChildren<VideoPlayer>();
        if (videoPlayer == null)
        {
            throw new System.Exception("No VideoPlayer found as child of Main Camera");
        }

        Debug.Log("[VideoControl] Found existing VideoPlayer on Main Camera");

        // Create entity to track the VideoPlayer
        var entity = EntityManager.CreateEntity();
        EntityManager.AddComponentData(entity, new VideoPlayerReference { Value = videoPlayer });

    }
    protected override void OnStartRunning()
    {
    }

    protected override void OnUpdate()
    {
        // Video player reference is handled in OnStartRunning
    }
}
