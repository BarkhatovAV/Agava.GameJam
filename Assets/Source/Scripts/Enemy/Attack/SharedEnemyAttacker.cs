using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedEnemyAttacker : SharedVariable<EnemyAttacker>
{
    public static implicit operator SharedEnemyAttacker(EnemyAttacker value)
        => new SharedEnemyAttacker { Value = value };
}