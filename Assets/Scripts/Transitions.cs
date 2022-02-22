using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transitions : MonoBehaviour
{
    [SerializeField] protected States _targetState;
    public States TargetState => _targetState;

    public bool NeedTransit { get; protected set; }
}
