using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Healer _template;

    private float _delayUntilTheNextBonus = 30;
    private bool _canSpawn = true;

    private void OnEnable()
    {
        _playerHealth.HealthCriticallyReduced += OnHealthCriticallyReduced;
    }

    private void OnDisable()
    {
        _playerHealth.HealthCriticallyReduced -= OnHealthCriticallyReduced;
    }

    private void OnHealthCriticallyReduced()
    {
        if(_canSpawn)
        {
            _canSpawn = false;
            StartCoroutine(WaitUntilTheNextBonus());
        }
    }

    private IEnumerator WaitUntilTheNextBonus()
    {
        yield return new WaitForSeconds(_delayUntilTheNextBonus);
        _canSpawn = true;
    }
}
