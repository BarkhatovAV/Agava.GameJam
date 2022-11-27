using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private List<Boost> _templates;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _delaySpawnTime;

    private Transform _lastSpawnPoint;
    private List<Boost> _boosts = new List<Boost>();

    private void Start()
    {
        for (int i = 0; i < _templates.Count; i++)
        {
            CreateBoost(i);           
        }

        DeactiveBoosts();
    }

    private void CreateBoost(int index)
    {
        Boost boost = Instantiate(_templates[index], transform);
        _boosts.Add(boost);
        boost.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            SpawnBoost();
    }

    private int GetRandomIndex(int elementsCount)
    {
        return Random.Range(0, elementsCount);
    }

    private void DeactiveBoosts()
    {
        for (int i = 0; i < _boosts.Count; i++)
            _boosts[i].gameObject.SetActive(false);
    }

    private void SpawnBoost()
    {
        Boost boost = GetRandomTemplate();
        boost.transform.position = GetRandomSpawnPoint().position;
        boost.gameObject.SetActive(true);
    }

    private Boost GetRandomTemplate()
    {
        int boostIndex = GetRandomIndex(_boosts.Count);

        if (_boosts[boostIndex].gameObject.activeSelf == false)
            return _boosts[boostIndex];
        else
            return GetRandomTemplate();
    }

    private Transform GetRandomSpawnPoint()
    {
        int spawnPointIndex = GetRandomIndex(_spawnPoints.Count);

        if (_spawnPoints[spawnPointIndex].gameObject.activeSelf == false)
            return _spawnPoints[spawnPointIndex];
        else
            return GetRandomSpawnPoint();

    }
}
