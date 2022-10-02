using System;
using System.Collections;
using UnityEngine;

public class EnemiesSpawner : ObjectsPool<Enemy>
{
    [Min(0)]
    [SerializeField] private float _secondsBetweenSpawn;
    [Min(0)]
    [SerializeField] private int _needCount;
    [Min(0)]
    [SerializeField] private int _countBetweenWaves;
    [Min(0)]
    [SerializeField] private float _secondsBetweenWaves;
    [SerializeField] private PlayerHealth _target;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _contaner;

    private int _spawned;

    public event Action<Enemy> Spawned;

    private void Start()
    {
        Initialize(_contaner);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delayBetweenSpawn = new WaitForSeconds(_secondsBetweenSpawn);
        var delayBetweenWave = new WaitForSeconds(_secondsBetweenWaves);

        while (_target != null && _spawned < _needCount && TryGetRandomObject(out Enemy enemy))
        {
            Initialize(enemy);
            Spawned?.Invoke(enemy);
            _spawned++;
            yield return delayBetweenSpawn;

            if (_spawned % _countBetweenWaves == 0)
                yield return delayBetweenWave;
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