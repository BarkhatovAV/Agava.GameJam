using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesSpawner : ObjectsPool<Enemy>
{
    [Min(0)]
    [SerializeField] private int _countBetweenWaves;
    [Min(0)]
    [SerializeField] private float _secondsBetweenWaves;
    [SerializeField] private PlayerHealth _target;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _contaner;

    private int _spawned;
    private int _maximumCount;
    private float _secondsBetweenSpawn;
    private EnemySpanwerSetter _enemySpanwerSetter;

    public int MaximumCount => _maximumCount;

    public event Action<Enemy> Spawned;

    private void Start()
    {
        _enemySpanwerSetter = new EnemySpanwerSetter();
        _secondsBetweenSpawn = _enemySpanwerSetter.TimeBetweenSpawn;
        _maximumCount = _enemySpanwerSetter.EnemiesCount;
        Initialize(_contaner);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds delayBetweenSpawn = new WaitForSeconds(_secondsBetweenSpawn);
        WaitForSeconds delayBetweenWave = new WaitForSeconds(_secondsBetweenWaves);

        while (_target != null && _spawned < _maximumCount && TryGetRandomObject(out Enemy enemy))
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

public class EnemySpanwerSetter
{
    private static int levelNumber = SceneManager.GetActiveScene().buildIndex;

    private int levelDifficulty = LevelsDifficultySaver.GetLevelDifficulty(levelNumber);
    private int _baseEnemiesCount = 150;

    public int Difficulty => levelDifficulty;
    public float TimeBetweenSpawn => GetSecondsBetweenSpawn();
    public int EnemiesCount => (int)(_baseEnemiesCount / GetSecondsBetweenSpawn());

    private float GetSecondsBetweenSpawn()
    {
        switch(levelDifficulty)
        {
            case 0:
                return 3f;
            case 1:
                return 2.5f;
            case 2:
                return 2f;
            case 3:
                return 1f;
            case 4:
                return 0.5f;
            case 5:
                return 0.5f;

            default:
                return 3f;
        }
    }
}