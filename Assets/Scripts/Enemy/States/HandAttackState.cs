using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttackState : EnemyState
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _attackDelay;

    private Coroutine _corutine;

    private void OnEnable()
    {
        _corutine = StartCoroutine(Attack());
    }

    private void OnDisable()
    {
        StopCoroutine(_corutine);
    }

    private IEnumerator Attack()
    {
        while(enabled)
        {
            Animator.SetTrigger("attack");
            yield return new WaitForSeconds(_attackDelay);
            Player.ApplyDamage(_attackForce);
        }
    }
}
