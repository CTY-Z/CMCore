using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
public class MustSubclassOf : Attribute
{
    public Type RequiredBaseType { get; }

    public MustSubclassOf(Type requiredBaseType)
    {
        //todo
        RequiredBaseType = requiredBaseType;
    }
}
