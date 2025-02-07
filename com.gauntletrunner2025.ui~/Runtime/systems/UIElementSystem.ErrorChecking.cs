using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;

public abstract partial class UIElementSystem<T, U> : SystemBase {
    private bool GetUIDocument(out UIDocument uiDocument, out VisualElement root) {
        uiDocument = GameObject.FindAnyObjectByType<UIDocument>();
        if (uiDocument == null) {
            Debug.LogError("UIDocument not found in the scene.");
            root = null;
            this.Enabled = false;
            return false;
        } else {
            root = uiDocument.rootVisualElement;
        }


        return true;
    }

    private bool LoadFromFile() {
        //this.Name is the name of the file- it should exist anywhere below a folder named Resources
        var asset = Resources.Load<VisualTreeAsset>(Name);
        if (asset == null) {
            Debug.LogError($"[{this.GetType().Name}]: UI VisualTreeAsset [{Name}] not found.");
            this.Enabled = false;
            return false;
        }

        //Clone the asset but do not add it to the parent
        var visualElement = asset.Instantiate();

        this.Element = visualElement.Q<T>(Name);

        if (Element == null) {
            Debug.LogError($"[{this.GetType().Name}]: [{typeof(T)}] [{Name}] not found in loaded file");
            this.Enabled = false;
            return false;
        }

        return true;
    }
    private bool GetUIElement(VisualElement root) {
        this.Element = root.Q<T>(Name);
        if (Element == null) {
            Debug.LogError($"[{this.GetType().Name}]: [{typeof(T)}] [{Name}] not found ");
            this.Enabled = false;
            return false;
        }
        return true;
    }

}