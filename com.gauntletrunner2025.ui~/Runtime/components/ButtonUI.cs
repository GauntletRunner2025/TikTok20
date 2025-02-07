using UnityEngine.UIElements;

public abstract partial class ButtonUI : UIElementSystem<Button, ButtonComponent>
{
    public Button Button => Element;
}
