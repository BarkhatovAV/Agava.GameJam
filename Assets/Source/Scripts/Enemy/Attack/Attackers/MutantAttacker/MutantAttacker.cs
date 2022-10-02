using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class MutantAttacker : EnemyAttacker
{
    [SerializeField] private BlastWave _blastWaveTempalte;

    private EnemyHealth _health;
    private bool _attacked;

    private void OnEnable()
    {
        _attacked = false;
    }

    protected override void Awake()
    {
        base.Awake();
        _health = GetComponent<EnemyHealth>();
    }

    protected override void Attack(ITarget target)
    {
        _attacked = true;
        BlastWave blastWave = Instantiate(_blastWaveTempalte, transform.position, Quaternion.identity);
        StartCoroutine(blastWave.Explode(_health.DelayBeforeDeath));
        _health.Kill();
    }

    protected override bool ConditionBeforeAttack()
    {
        return _attacked == false;
    }
}