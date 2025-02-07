using System;
using UnityEngine;
using System.Linq;
using Unity.Entities;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public partial class ListViewComponent : IComponentData, IValueComponent<ListView> {
    public ListView Value;

    ListView IValueComponent<ListView>.ValueOuter {
        get => Value;
        set => Value = value;
    }
}