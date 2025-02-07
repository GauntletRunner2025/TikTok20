using UnityEngine.UIElements;

public abstract partial class LabelUI : UIElementSystem<Label, LabelComponent>
{
    public Label Label => Element;
}
