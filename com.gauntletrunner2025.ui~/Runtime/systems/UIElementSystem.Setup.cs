using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;

public abstract partial class UIElementSystem<T, U> : SystemBase {
    bool Setup(out UIDocument uiDocument, out VisualElement root) {
        root = null;

        //Get the overall UI, pass in the root to be populated
        if (!GetUIDocument(out uiDocument, out root))
            return false;


        //Get the UI element from the existing DOM 
        if (SourceMode == ElementSourceMode.ExistsInTree) {
            if (!GetUIElement(root))
                return false;

        } else if (SourceMode == ElementSourceMode.FileOnDisk) {
            //Try and load the file from disk
            //This does not add the element to the parent, so derived systems must look for where to attach it
            if (!LoadFromFile())
                return false;
        }

        return true;
    }
}