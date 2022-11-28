using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private List<Boost> _templates;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _delaySpawnTime;
    [SerializeField] private int _maxNumberSpawnAtSameTime;
    [SerializeField] private int _countExemplarsTemplate;

    private int _currentSpawned;
    private Transform _lastSpawnPoint;
    private Coroutine _coroutine;
    private List<Boost> _boosts = new List<Boost>();

    private void Start()
    {
        FillPool();
        TrySpawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            SpawnBoost();
    }

    private void OnDisable()
    {
        for (int i = 0; i < _boosts.Count; i++)
            _boosts[i].Taken -= OnTaken;
    }


    private void CreateBoost(int index)
    {
        Boost boost = Instantiate(_templates[index], transform);
        _boosts.Add(boost);
        boost.Taken += OnTaken;
        boost.gameObject.SetActive(false);
    }

    private void OnTaken()
    {
        _currentSpawned--;
        TrySpawn();
    }

    private void FillPool()
    {
        for (int i = 0; i < _templates.Count; i++)
            for (int j = 0; j < _countExemplarsTemplate; j++)
                CreateBoost(i);
    }


    private int GetRandomIndex(int elementsCount)
    {
        return Random.Range(0, elementsCount);
    }


    private void SpawnBoost()
    {
        Boost boost = GetRandomTemplate();
        boost.transform.position = GetRandomSpawnPoint().position;
        boost.gameObject.SetActive(true);
        _currentSpawned++;
        _coroutine = null;
        print("Spawned");
        TrySpawn();
    }

    private void TrySpawn()
    {
        print(_coroutine == null);
        print(_coroutine);
        print(_currentSpawned <= _maxNumberSpawnAtSameTime);

        if ((_coroutine == null) && (_currentSpawned < _maxNumberSpawnAtSameTime))
            _coroutine = StartCoroutine(OnWaitingSpawn());
    }

    private Boost GetRandomTemplate()
    {
        while(true)
        {
            int boostIndex = GetRandomIndex(_boosts.Count);

            if (_boosts[boostIndex].gameObject.activeSelf == false)
                return _boosts[boostIndex];
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        while(true)
        {
            int spawnPointIndex = GetRandomIndex(_spawnPoints.Count);

            if (_spawnPoints[spawnPointIndex] != _lastSpawnPoint)
            {
                _lastSpawnPoint = _spawnPoints[spawnPointIndex];
                return _lastSpawnPoint;
            }
        }
    }

    private IEnumerator OnWaitingSpawn()
    {
        print("enterCoroutine");
        yield return new WaitForSeconds(_delaySpawnTime);
        SpawnBoost();
    }
}
