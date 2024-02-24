using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : ITransformBehaviour
{
    private Transform _targetTransform;

    private Vector3 _rotateDirection = Vector3.up;

    private float _rotationSpeed;

    public Rotate(Entity entity)
    {
        _targetTransform = entity.transform;
        _rotationSpeed = entity.Settings.RotationSpeed;
    }

    public void Action(float fixedDeltaTime)
    {
        _targetTransform.Rotate(_rotateDirection, fixedDeltaTime * _rotationSpeed);
    }
}