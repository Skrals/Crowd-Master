using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected Animator _animator;
    protected HealthContainer _health;
    private States _states;
    protected void OnEnable()
    {
        _health.Died += OnDie;
    }

    protected void OnDisable()
    {
        _health.Died -= OnDie;
    }

    protected void LoadFromAwake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthContainer>();
    }

    protected abstract void OnDie();

}
