using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : States
{
    [SerializeField] private PlayerTransition[] _transitions;
    public  override void Enter(Rigidbody rigidbody , Animator animator)
    {
        if(enabled == false)
        {
            Rigidbody = rigidbody;
            Animator = animator; 

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public override void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public PlayerState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if(transition.NeedTransit)
            {
                return (PlayerState)transition.TargetState;
            }
        }
        return null;
    }
}
