using BehaviorDesigner.Runtime.Tasks;

public class AttackStopping : Action
{
    public SharedEnemyAttacker EnemyAttacker;

    public override TaskStatus OnUpdate()
    {
        EnemyAttacker.Value.StopAttack();
        return TaskStatus.Success;
    }
}