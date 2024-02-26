using System;
using System.Collections.Generic;
using System.Linq;

public static class TransformBehaviourExtension
{
    public static IEnumerable<Enum> GetFlags(Enum input) 
    {
        foreach (Enum value in Enum.GetValues(input.GetType()))
            if (input.HasFlag(value))
               yield return value;
    }

    public static ITransformBehaviour GetBehaviour(Entity entity, BehaviourType flag)
    {
        return flag switch
        {
            BehaviourType.Move => new MovementComponent(entity),
            BehaviourType.Rotate => new RotationComponent(entity),
            BehaviourType.Grow => new GrowthComponent(entity),
            _ => null,
        };
    }
}

[System.Flags]
public enum BehaviourType
{
    Move = 1 << 0,
    Rotate = 1 << 1,
    Grow = 1 << 2
}