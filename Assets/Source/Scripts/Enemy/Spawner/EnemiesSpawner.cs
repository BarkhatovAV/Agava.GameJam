using System;
using System.Collections;
using UnityEngine;

public class EnemiesSpawner : ObjectsPool<Enemy>
{
    [Min(0)]
    [SerializeField] private float _secondsBetweenSpawn;
    [Min(0)]
    [SerializeField] private int _needCount;
    [SerializeField] private PlayerHealth _targetBehaviour;
    [SerializeField] private Transform[] _spawnPoints;

    private ITarget _target;
    private int _spawned;

    public event Action<Enemy> Spawned;

    private void Start()
    {
        Initialize(transform);
        _target = _targetBehaviour;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(_secondsBetweenSpawn);

        while (_target != null && _spawned < _needCount && TryGetRandomObject(out Enemy enemy))
        {
            Initialize(enemy);
            Spawned?.Invoke(enemy);
            _spawned++;
            yield return delay;
        }
    }

    private void Initialize(Enemy enemy)
    {
        enemy.transform.position = GetRandomSpawnPoint();
        enemy.Activate();
        enemy.Initialize(_target);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)].position;
    }
}