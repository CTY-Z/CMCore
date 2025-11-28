using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBase
{
    protected string fsmName;

    public virtual string FSMName { get { return fsmName; } private set { fsmName = value ?? string.Empty; } }
}
