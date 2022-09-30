using BehaviorDesigner.Runtime.Tasks;

public class AttackOnTarget : Action
{
    public SharedEnemyAttacker EnemyAttacker;

    public override TaskStatus OnUpdate()
    {
        EnemyAttacker.Value.Attack();
        return TaskStatus.Success;
    }
}