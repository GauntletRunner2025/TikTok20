using Unity.Entities;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Video;

public partial class VideoInitialize : SystemBase
{
    protected override void OnUpdate()
    {

        using EntityCommandBuffer ecb  = new EntityCommandBuffer(Allocator.TempJob);

        foreach ((VideoUrl url, Entity entity) in 
            SystemAPI.Query<VideoUrl>().WithEntityAccess())
        {
            if (string.IsNullOrEmpty(url.Value))
            {
                Debug.LogError("Video URL is null or empty");
                continue;
            }

            var camera = GameObject.Find("Main Camera");
            if (camera == null)
            {
                Debug.LogError("Main Camera not found");
                continue;
            }

            var videoPlayer = camera.AddComponent<VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.url = url.Value;

            ecb.AddComponent(entity, new VideoPlayerReference 
            { 
                Value = videoPlayer 
            });

            ecb.RemoveComponent<VideoUrl>(entity);
        }

        ecb.Playback(EntityManager);
    }
}
