using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMFramework.Core.EventPool
{
    public class BaseEventArgs : IRefPoolItem
    {
        public int idx { get; set; }
    }
}

