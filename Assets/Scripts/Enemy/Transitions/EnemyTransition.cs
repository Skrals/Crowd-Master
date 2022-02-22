using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTransition : Transitions
{
    protected PlayerStateMachine Player { get; private set; }

    public void Init(PlayerStateMachine player)
    {
        Player = player;
    }
    
    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}
