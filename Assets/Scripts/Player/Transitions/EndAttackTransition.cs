using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttackTransition : PlayerTransition
{
    [SerializeField] private AttackState _attackState;

    public override void Enable()
    {
        _attackState.AbilityEnded += OnAbillityEnded;
    }

    private void OnDisable()
    {
        _attackState.AbilityEnded -= OnAbillityEnded;
    }

    private void OnAbillityEnded ()
    {
        NeedTransit = true;
    }

    void Update()
    {
        
    }
}
