using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public partial class VideoSeek : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SeekRequest>();
        Debug.Log("[VideoSeek] System created and waiting for seek requests");
    }

    protected override void OnUpdate()
    {
        var videoPlayer = SystemAPI.ManagedAPI.GetSingleton<VideoPlayerReference>().Value;
        if (videoPlayer == null)
        {
            throw new System.Exception("VideoPlayer reference is null");
        }

        using EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);

        foreach ((SeekRequest request, Entity entity) in SystemAPI.Query<SeekRequest>().WithEntityAccess())
        {
            var newValue = (request.Value / 100) * videoPlayer.length;
            Debug.Log($"[VideoSeek] Seeking video to {newValue}");
            videoPlayer.time = newValue;
            ecb.DestroyEntity(entity);
        }

        ecb.Playback(EntityManager);
    }
}
