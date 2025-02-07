using UnityEngine.UIElements;

public abstract partial class TextFieldUI : UIElementSystem<TextField, TextFieldComponent>
{
    public TextField TextField => Element;
}
