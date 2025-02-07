using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public partial class AudioPauseToggle : Listener
{
    public override ComponentType EventType => typeof(PauseToggleRequest);

    public override ComponentType HandledFlagType => typeof(Handled);

    struct Handled : IComponentData { }

    public override bool OnEvent(EntityManager em, Entity e)
    {

        var entity = SystemAPI.ManagedAPI.GetSingletonEntity<AudioClipReference>();
        var audioSource = SystemAPI.ManagedAPI.GetComponent<AudioClipReference>(entity).Value;

        if (SystemAPI.HasComponent<IsPaused>(entity))
        {
            em.RemoveComponent<IsPaused>(entity);
            audioSource.Play();
        }
        else
        {
            em.AddComponent<IsPaused>(entity);
            audioSource.Pause();
        }

        return true;
    }
}
