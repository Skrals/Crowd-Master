using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;

    private Abillity _currentAbility;

    public event UnityAction<IDamageble> CollisionDetected;
    public event UnityAction AbilityEnded;

    private void OnEnable()
    {
        Animator.SetTrigger("attack");
        _currentAbility = _staminaAccumulator.GetAbility();
        _currentAbility.AbilityEnded += OnAbillityEnded;

        _currentAbility.UseAbillity(this);
    }

    private void OnDisable()
    {
        _currentAbility.AbilityEnded -= OnAbillityEnded;
    }

    private void OnAbillityEnded()
    {
        AbilityEnded?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble damageble))
        {
            CollisionDetected?.Invoke(damageble);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent (out IDamageble damageble))
        {
            CollisionDetected?.Invoke(damageble);
        }
    }

    private void Update()
    {
        
    }
}
