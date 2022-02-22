using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerTransition : Transitions
{

    private void OnEnable()
    {
        NeedTransit = false;
        Enable();
    }

    public abstract void Enable();
}
