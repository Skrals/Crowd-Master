using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States : MonoBehaviour
{
    public Rigidbody Rigidbody { get; protected set; }

    public Animator Animator { get; protected set; }

    public abstract void Exit();

    public virtual void Enter(Rigidbody rigidbody, Animator animator) { }

    public virtual void Enter(Rigidbody rigidbody, Animator animator, PlayerStateMachine player) { }

  
}
