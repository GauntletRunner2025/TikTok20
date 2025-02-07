using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;

public partial class PauseButtonSystem : UIElementSystem<Button, ButtonComponent>
{
    protected override string Name => "PauseButton";

    protected override ElementSourceMode SourceMode => ElementSourceMode.ExistsInTree;

    protected override void Initialize(VisualElement root, Button element)
    {
        element.clickable.clicked += Do;
    }

    protected override void OnUpdate()
    {
        if (Clicked)
        {
            Clicked = false;
            Log("Pause button is clicked");

            var e = EntityManager.CreateEntity();
            EntityManager.AddComponentData(e, new PauseToggleRequest());
            EntityManager.AddComponentData(e, new Request());
        }
    }

    bool Clicked = false;

    void Do()
    {
        Clicked = !Clicked;
    }
}