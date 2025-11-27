using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMFramework.Core
{
    public struct ObjectCtorData<T>
    {
        public string name;
        public int initialCapacity;
        public Func<T> factory;
        public bool allowGrow;
#nullable enable
        public Action<T>? OnRent;
        public Action<T>? OnReturn;
        public bool isPrepareItem;

        public ObjectCtorData(string name, int initialCapacity, Func<T> factory, bool allowGrow = false,
            Action<T>? OnRent = null, Action<T>? OnReturn = null, bool isPrepareItem = false)
        {
            this.name = name;
            this.initialCapacity = initialCapacity;
            this.factory = factory;
            this.allowGrow = allowGrow;
            this.OnRent = OnRent;
            this.OnReturn = OnReturn;
            this.isPrepareItem = isPrepareItem;
        }
#nullable disable
    }
}
