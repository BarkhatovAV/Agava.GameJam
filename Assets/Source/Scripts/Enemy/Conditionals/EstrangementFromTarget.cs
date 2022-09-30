using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class EstrangementFromTarget : Conditional
{
    public SharedInt TargetDistance;
    public SharedEnemyMover EnemyMover;

    public override TaskStatus OnUpdate()
        => EnemyMover.Value.DistanceToTarget > TargetDistance.Value ? TaskStatus.Success : TaskStatus.Failure;
}