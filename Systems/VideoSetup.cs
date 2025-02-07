using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public partial class VideoSetup : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        // Only create the video entity if it doesn't exist yet
        if (!SystemAPI.ManagedAPI.HasSingleton<VideoPlayerReference>())
        {
            var videoPath = Application.dataPath + "/Resources/sample.mp4";
            if (!System.IO.File.Exists(videoPath))
            {
                Debug.LogError($"Video file not found at {videoPath}");
                return;
            }

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            
            var entity = ecb.CreateEntity();
            
            ecb.AddComponent(entity, new VideoUrl 
            { 
                Value = videoPath 
            });
            
            ecb.AddComponent(entity, new VideoPlaybackSpeed 
            { 
                Value = 1.0f 
            });
            
            ecb.AddComponent(entity, new VideoIsLooping 
            { 
                Value = true 
            });
            
            ecb.AddComponent<PlayVideo>(entity);

            // Disable this system after it runs once
            Enabled = false;
            
        }
    }
}
