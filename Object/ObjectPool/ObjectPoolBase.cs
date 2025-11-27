using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMFramework.Core
{
    public class ObjectPoolBase
    {
        protected string poolName;

        public virtual string PoolName { get { return poolName; } }
    }
}
