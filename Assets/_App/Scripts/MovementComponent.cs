using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : ITransformBehaviour
{
    private Transform _targetTransform;
    private float _movementSpeed;

    public MovementComponent(Entity entity)
    {
        _targetTransform = entity.transform;
        _movementSpeed = entity.Settings.MovementSpeed;
    }

    public void Action(float fixedDeltaTime)
    {
        _targetTransform.position += _movementSpeed * fixedDeltaTime * _targetTransform.forward;
    }
}