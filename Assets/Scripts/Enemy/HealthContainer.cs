using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private BrokenState _broken;

    public UnityAction<int> HealthChanged;
    public UnityAction Died;

    public void TakeDamage(int value)
    {
        _health -= value;
        if(_health <=0)
        {
            _health = 0;
            Died?.Invoke();
            _broken.Animator.SetTrigger("broken");
        }
        Debug.Log(_health);
        HealthChanged?.Invoke(_health);
    }

}
