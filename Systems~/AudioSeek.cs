using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public partial class AudioSeek : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SeekRequest>();
        Debug.Log("[AudioSeek] System created and waiting for seek requests");
    }

    protected override void OnUpdate()
    {
        var audioSource = SystemAPI.ManagedAPI.GetSingleton<AudioClipReference>().Value;
        if (audioSource == null)
        {
            throw new System.Exception("AudioSource reference is null");
        }

        using EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);

        foreach ((SeekRequest request, Entity entity) in SystemAPI.Query<SeekRequest>().WithEntityAccess())
        {
            Debug.Log($"[AudioSeek] Seeking audio to {request.Value:F2}s");
            audioSource.time = request.Value;
        }

        ecb.Playback(EntityManager);
    }
}
