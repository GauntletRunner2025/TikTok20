using Unity.Entities;
using UnityEngine.UIElements;

public abstract partial class ProgressBarUI : UIElementSystem<ProgressBar, ProgressBarComponent>
{
    public ProgressBar ProgressBar => Element;
}

public partial class ProgressBarComponent : IComponentData, IValueComponent<ProgressBar>
{
    public ProgressBar Value;

    ProgressBar IValueComponent<ProgressBar>.ValueOuter
    {
        get => Value;
        set => Value = value;
    }
}