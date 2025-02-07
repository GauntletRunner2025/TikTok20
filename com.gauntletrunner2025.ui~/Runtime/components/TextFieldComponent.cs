using System;
using UnityEngine;
using System.Linq;
using Unity.Entities;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public partial class TextFieldComponent : IComponentData, IValueComponent<TextField> {
    public TextField Value;

    TextField IValueComponent<TextField>.ValueOuter {
        get => Value;
        set => Value = value;
    }
}