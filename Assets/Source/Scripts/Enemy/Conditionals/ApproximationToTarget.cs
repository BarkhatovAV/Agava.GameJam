using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ApproximationToTarget : Conditional
{
    public SharedFloat TargetDistance;
    public SharedEnemyVision EnemyVision;

    public override TaskStatus OnUpdate()
    {
        return CanAttack() ? TaskStatus.Success : TaskStatus.Failure;
    }

    private bool CanAttack()
    {
        return EnemyVision.Value.DistanceToTarget < TargetDistance.Value && EnemyVision.Value.TargetIsVisible;
    }
}