using BehaviorDesigner.Runtime.Tasks;

public class MovementStopping : Action
{
    public SharedEnemyMover EnemyMover;

    public override TaskStatus OnUpdate()
    {
        EnemyMover.Value.StopMoving();
        return TaskStatus.Success;
    }
}