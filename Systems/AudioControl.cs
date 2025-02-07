using Unity.Entities;
using UnityEngine;

public partial class AudioControl : SystemBase
{
    protected override void OnStartRunning()
    {
        //Find it using the GameObject 
        var g = GameObject.FindFirstObjectByType<AudioSource>();
        if (g == null)
        {
            throw new System.Exception("No AudioSource found in scene");
        }
        var audioSource = g.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            throw new System.Exception("No AudioSource found on VideoPlayer");
        }

        var entity = EntityManager.CreateEntity();
        EntityManager.AddComponentData(entity, new AudioClipReference { Value = audioSource });
    }

    protected override void OnUpdate()
    {
    }
}
