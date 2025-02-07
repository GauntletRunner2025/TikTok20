using UnityEngine.UIElements;

public interface IValueComponent<T> where T : VisualElement
{
    T ValueOuter { get; set; }
}
