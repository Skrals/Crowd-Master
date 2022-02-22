using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public class PlayerStateMachine : StateMachine
{
    [SerializeField] private PlayerState _firstState;

    private PlayerState _currentState;

    public UnityAction Damaged;

    protected override void OnDie()
    {
        enabled = false;
        _animator.SetTrigger("broken");
    }

    private void Awake()
    {
        LoadFromAwake();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        PlayerState nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(PlayerState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_rigidbody, _animator);
        }
    }

    public void ApplyDamage(float damage)
    {
        Damaged?.Invoke();
        _health.TakeDamage((int)damage);
    }
}
