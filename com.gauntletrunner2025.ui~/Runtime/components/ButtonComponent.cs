using Unity.Entities;
using UnityEngine.UIElements;

public partial class ButtonComponent : IComponentData, IValueComponent<Button>
{
    public Button Value;

    Button IValueComponent<Button>.ValueOuter
    {
        get => Value;
        set => Value = value;
    }
}
