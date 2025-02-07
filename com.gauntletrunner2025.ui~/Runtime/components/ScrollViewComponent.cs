using System;
using UnityEngine;
using System.Linq;
using Unity.Entities;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public partial class ScrollViewComponent : IComponentData, IValueComponent<ScrollView> {
    public ScrollView Value;

    ScrollView IValueComponent<ScrollView>.ValueOuter {
        get => Value;
        set => Value = value;
    }
}