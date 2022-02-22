using UnityEngine;

public class EnemyState : States
{
    [SerializeField] private EnemyTransition[] _transitions;

    public PlayerStateMachine Player { get; private set; }

    public override void Enter(Rigidbody rigidbody, Animator animator, PlayerStateMachine player)
    {
        if (enabled == false)
        {
            Rigidbody = rigidbody;
            Animator = animator;
            Player = player;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Player);
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

    public EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return (EnemyState)transition.TargetState;
            }
        }
        return null;
    }
}
