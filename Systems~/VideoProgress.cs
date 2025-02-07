using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public partial class VideoProgress : ProgressBarUI
{
    protected override string Name => "VideoProgress";

    protected override ElementSourceMode SourceMode => ElementSourceMode.ExistsInTree;


    protected override void Initialize(VisualElement root, ProgressBar element)
    {
        Debug.Log("[VideoProgress] Found video player and initializing progress bar");
        element.lowValue = 0;
        element.highValue = 100;
    }

    protected override void OnUpdate()
    {

        //Find the video playher singleton
        var videoPlayer = SystemAPI.ManagedAPI.GetSingleton<VideoPlayerReference>().Value;


        float percentage = (float)(videoPlayer.time / videoPlayer.length) * 100;
        if (!Mathf.Approximately(Element.value, percentage))
        {
            Debug.Log($"[VideoProgress] Updating progress to {percentage:F1}% (time: {videoPlayer.time:F2}s / {videoPlayer.length:F2}s)");
            Element.value = percentage;
            Element.title = $"{percentage:F0}%";
        }
    }
}