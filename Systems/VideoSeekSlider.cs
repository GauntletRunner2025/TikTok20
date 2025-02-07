using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;

public partial class VideoSeekSlider : SliderUI
{
    protected override string Name => "VideoSeekSlider";

    protected override ElementSourceMode SourceMode => ElementSourceMode.ExistsInTree;

    public float SeekRequest = 0;

    protected override void Initialize(VisualElement root, Slider element)
    {
        //Register handler of value changed
        element.RegisterValueChangedCallback(evt =>
        {
            //Get the value of the slider
            SeekRequest = evt.newValue;
            Debug.Log($"VideoSeekSlider value changed to {SeekRequest}");

        });
    }

    protected override void OnUpdate()
    {
        if (SeekRequest == 0)
            return;

        Debug.Log($"[VideoSeekSlider] emitting seek request {SeekRequest}");
        var e = EntityManager.CreateEntity();
        EntityManager.AddComponentData(e, new SeekRequest { Value = SeekRequest });
        SeekRequest = 0;
    }
}