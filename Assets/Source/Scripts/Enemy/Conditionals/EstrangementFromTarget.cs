using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class EstrangementFromTarget : Conditional
{
    public SharedFloat TargetDistance;
    public SharedEnemyVision EnemyVision;

    public override TaskStatus OnUpdate()
    {
        return CanMove() ? TaskStatus.Success : TaskStatus.Failure;
    }

    private bool CanMove()
    {
        return EnemyVision.Value.DistanceToTarget > TargetDistance.Value || EnemyVision.Value.TargetIsVisible == false;
    }
}