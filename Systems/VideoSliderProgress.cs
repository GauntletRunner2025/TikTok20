using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public partial class VideoSliderProgress : SliderUI
{
    protected override string Name => "VideoSeekSlider";

    protected override ElementSourceMode SourceMode => ElementSourceMode.ExistsInTree;

    protected override void Initialize(VisualElement root, Slider element)
    {
        element.showInputField = false;
    }


    protected override void OnUpdate()
    {
        var videoPlayer = SystemAPI.ManagedAPI.GetSingleton<VideoPlayerReference>().Value;
        if (videoPlayer == null)
        {
            throw new System.Exception("VideoPlayer reference is null");
        }

        float percentage = (float)(videoPlayer.time / videoPlayer.length) * 100;
        if (!Mathf.Approximately(Element.value, percentage))
        {
            Element.SetValueWithoutNotify(percentage);
        }
    }
}
