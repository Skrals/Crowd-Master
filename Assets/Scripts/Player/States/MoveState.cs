using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private StaminaAccumulator _staminaAccumulator;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRation;

    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDiractionChanged;
        _staminaAccumulator.StartAccumulate();
    }

    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDiractionChanged;
    }

    private void OnDiractionChanged(Vector2 direction)
    {
        Rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * _speedRation;
        if (Rigidbody.velocity.magnitude > _maxSpeed)
        {
            Rigidbody.velocity *= _maxSpeed / Rigidbody.velocity.magnitude;
        }
        if (Rigidbody.velocity.magnitude != 0)
        {
            Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));
        }
    }

}
