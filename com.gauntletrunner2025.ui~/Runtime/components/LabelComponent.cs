using System;
using UnityEngine;
using System.Linq;
using Unity.Entities;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public partial class LabelComponent : IComponentData, IValueComponent<Label> {
    public Label Value;

    Label IValueComponent<Label>.ValueOuter {
        get => Value;
        set => Value = value;
    }
}