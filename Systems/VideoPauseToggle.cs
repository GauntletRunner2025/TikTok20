using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public partial class VideoPauseToggle : Listener
{
    public override ComponentType EventType => typeof(PauseToggleRequest);

    public override ComponentType HandledFlagType => typeof(Handled);

    struct Handled : IComponentData { }

    public override bool OnEvent(EntityManager em, Entity e)
    {

        var videoEntity = SystemAPI.ManagedAPI.GetSingletonEntity<VideoPlayerReference>();
        var videoPlayer = SystemAPI.ManagedAPI.GetSingleton<VideoPlayerReference>().Value;
        if (videoPlayer == null)
        {
            throw new System.Exception("VideoPlayer reference is null");
        }

        if (SystemAPI.HasComponent<IsPaused>(videoEntity))
        {
            em.RemoveComponent<IsPaused>(videoEntity);
            videoPlayer.Play();
        }
        else
        {
            em.AddComponent<IsPaused>(videoEntity);
            videoPlayer.Pause();
        }

        return true;
    }
}
