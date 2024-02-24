using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private BehaviourType _behaviourType;
    [SerializeField]
    private EntitySettings _settings;

    public EntitySettings Settings => _settings;
    public BehaviourType BehaviourType => _behaviourType;

    private List<ITransformBehaviour> _transformBehaviours;

    private void Awake()
    {
        _transformBehaviours = new List<ITransformBehaviour>();

        foreach (BehaviourType flag in TransformBehaviourExtension.GetFlags(_behaviourType))
            _transformBehaviours.Add(TransformBehaviourExtension.GetBehaviour(this, flag));
    }

    private void FixedUpdate()
    {
        foreach (var transformBehaviour in _transformBehaviours)
            transformBehaviour?.Action(Time.fixedDeltaTime);
    }
}

[Serializable]
public class EntitySettings
{
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _growSpeed;

    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float GrowSpeed => _growSpeed;
}