using System;
using System.Collections;
using UnityEngine;

public class EnemiesSpawner : ObjectsPool<Enemy>
{
    [Min(0)]
    [SerializeField] private float _secondsBetweenSpawn;
    [Min(0)]
    [SerializeField] private int _maximumCount;
    [Min(0)]
    [SerializeField] private int _countBetweenWaves;
    [Min(0)]
    [SerializeField] private float _secondsBetweenWaves;
    [SerializeField] private PlayerHealth _target;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _contaner;

    private int _spawned;

    public int MaximumCount => _maximumCount;

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

        while (_target != null && _spawned < _maximumCount && TryGetRandomObject(out Enemy enemy))
        {
            Initialize(enemy);
            Spawned?.Invoke(enemy);
            _spawned++;
            yield return delayBetweenSpawn;

            if (_spawned % _countBetweenWaves == 0)
                yield return delayBetweenWave;
        }

        Debug.Log(_target != null);
        Debug.Log(_spawned < _maximumCount);
        Debug.Log(_spawned);
        Debug.Log(TryGetRandomObject(out Enemy _));
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