using BehaviorDesigner.Runtime.Tasks;

public class MovementToTarget : Action
{
    public SharedEnemyMover EnemyMover;

    public override TaskStatus OnUpdate()
    {
        EnemyMover.Value.MoveToTarget();
        return TaskStatus.Success;
    }
}