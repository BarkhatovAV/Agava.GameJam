using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedEnemyMover : SharedVariable<EnemyMover>
{
    public static implicit operator SharedEnemyMover(EnemyMover value) 
        => new SharedEnemyMover { Value = value };
}