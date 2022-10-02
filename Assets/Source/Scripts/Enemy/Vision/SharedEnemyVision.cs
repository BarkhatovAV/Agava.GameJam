using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedEnemyVision : SharedVariable<EnemyVision>
{
    public static implicit operator SharedEnemyVision(EnemyVision value)
        => new SharedEnemyVision { Value = value };
}