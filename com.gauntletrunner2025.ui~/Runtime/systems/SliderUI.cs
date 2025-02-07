using Unity.Entities;
using UnityEngine.UIElements;

public abstract partial class SliderUI : UIElementSystem<Slider, SliderComponent>
{
    public Slider Slider => Element;
}

public partial class SliderComponent : IComponentData, IValueComponent<Slider>
{
    public Slider Value;

    Slider IValueComponent<Slider>.ValueOuter
    {
        get => Value;
        set => Value = value;
    }
}