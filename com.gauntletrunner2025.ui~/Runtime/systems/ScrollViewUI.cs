using UnityEngine.UIElements;

public abstract partial class ScrollViewUI : UIElementSystem<ScrollView, ScrollViewComponent>
{
    public ScrollView ScrollView => Element;
}
