using UnityEngine;

public class ParasiteAttacker : EnemyAttacker
{
    [Min(0)]
    [SerializeField] private int _damage;

    protected override void Attack(ITarget target)
    {
        target.TryTakeDamage(_damage);
    }

    protected override bool ConditionBeforeAttack()
    {
        return ElapsedTime > SecondsBetweenAttack;
    }
}