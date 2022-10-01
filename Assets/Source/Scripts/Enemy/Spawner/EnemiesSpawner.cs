using System;
using System.Collections;
using UnityEngine;

public class EnemiesSpawner : ObjectsPool<Enemy>
{
    [Min(0)]
    [SerializeField] private float _secondsBetweenSpawn;
    [Min(0)]
    [SerializeField] private int _needCount;
    [SerializeField] private MonoBehaviour _targetBehaviour;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform[] _spawnPoints;

    private ITarget _target;
    private int _spawned;

    public event Action<Enemy> Spawned;

    private void OnValidate()
    {
        if (_targetBehaviour && !(_targetBehaviour is ITarget))
        {
            Debug.LogError(nameof(_targetBehaviour) + " needs to implement " + nameof(ITarget));
            _targetBehaviour = null;
        }
    }

    private void Start()
    {
        Initialize(_container);
        _target = (ITarget)_targetBehaviour;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(_secondsBetweenSpawn);

        if (_target != null && _spawned < _needCount && TryGetRandomObject(out Enemy enemy))
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