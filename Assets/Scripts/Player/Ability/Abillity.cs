using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Abillity : ScriptableObject
{
    protected Rigidbody Rigidbody;

    public abstract event UnityAction AbilityEnded;

    public void Init (Rigidbody rigidbody)
    {
        Rigidbody = rigidbody;
    }

    public abstract void UseAbillity(AttackState attack);
}
