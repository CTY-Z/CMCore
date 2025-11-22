using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMFramework.Core.Collections
{
    public static class ListExtension
    {
        public static bool AddUnique<T>(this List<T> list, T item)
        {
            if (list.Contains(item))
                return false;

            list.Add(item);
            return true;
        }
    }
}
    

