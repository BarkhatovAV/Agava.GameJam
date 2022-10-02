using System;
using System.Collections.Generic;
using UnityEngine;

public class KillsCounter : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    private List<Enemy> _enemies = new List<Enemy>();
    private int _currentCount;
    private Vector3 _lastEnemyDeathPoint;

    public event Action LimitReached;
    public event Action<int> KillsCountChanged;

    public int MaxEnemy => _enemiesSpawner.MaximumCount;
    public Vector3 LastEnemyDeathPoint => _lastEnemyDeathPoint;

    private void OnValidate()
    {
        _enemiesSpawner = FindObjectOfType<EnemiesSpawner>();
    }

    private void OnEnable()
    {
        _enemiesSpawner.Spawned += OnSpawned;
    }

    private void OnDisable()
    {
        _enemiesSpawner.Spawned += OnSpawned;

        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    private void OnSpawned(Enemy enemy)
    {
        if(!_enemies.Contains(enemy))
        {
            enemy.Died += OnEnemyDied;
            _enemies.Add(enemy);
        }
    }

    private void OnEnemyDied(Vector3 point)
    {
        _lastEnemyDeathPoint = point;
        _currentCount++;
        KillsCountChanged?.Invoke(_currentCount);

        if (_currentCount >= MaxEnemy)
        {
            LimitReached?.Invoke();
        }
    }
}
