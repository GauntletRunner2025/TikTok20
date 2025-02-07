using UnityEngine.UIElements;

public abstract partial class ListViewUI : UIElementSystem<ListView, ListViewComponent> {
    public ListView ListView => Element;
}
