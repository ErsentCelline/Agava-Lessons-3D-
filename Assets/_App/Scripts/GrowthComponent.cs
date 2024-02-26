using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthComponent : ITransformBehaviour
{
    private Transform _targetTransform;

    private Vector3 _growDirection = Vector3.one;

    private float _growSpeed;

    public GrowthComponent(Entity entity)
    {
        _targetTransform = entity.transform;
        _growSpeed = entity.Settings.GrowSpeed;
    }

    public void Action(float fixedDeltaTime)
    {
        _targetTransform.localScale += fixedDeltaTime * _growSpeed * _growDirection;
    }
}