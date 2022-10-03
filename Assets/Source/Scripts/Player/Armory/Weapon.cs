using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _shotDistance;
    [SerializeField] private float _delayBetweenShots;

    private readonly List<Enemy> _enemies = new List<Enemy>();

    protected float _lastTimeShot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);
            enemy.HealthEnded += OnHealthEnded;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy) && _enemies.Contains(enemy))
            _enemies.Remove(enemy);
    }

    public virtual void Fire()
    {
        if (_enemies.Count != 0 && TryGetNearestEnemy(out Enemy enemy))
            enemy.Apply(_damage);

    }

    protected bool CheckDelay()
    {
        if(_lastTimeShot + _delayBetweenShots < Time.time)
        {
            _lastTimeShot = Time.time;
            return true;
        }
        else
            return false;            
    }

    private bool TryGetNearestEnemy(out Enemy target)
    {
        target = _enemies[0];

        float distance = Vector3.Distance(transform.position, target.transform.position);

        foreach (var enemy in _enemies)
        {
            float newDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (newDistance < distance)
            {
                distance = newDistance;
                target = enemy;
            }
        }

        return target != null;
    }

    private void OnHealthEnded(Enemy enemy) 
    {
        enemy.HealthEnded -= OnHealthEnded;

        if (_enemies.Contains(enemy))
            _enemies.Remove(enemy);
    }
}
