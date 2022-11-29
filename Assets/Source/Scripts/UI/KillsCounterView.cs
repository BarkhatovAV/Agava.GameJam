using UnityEngine;

public class KillsCounterView : UIBar
{
    [SerializeField] private KillsCounter _killsCounter;


    private void OnValidate()
    {
        _killsCounter = FindObjectOfType<KillsCounter>();
    }

    private void OnEnable()
    {
        _killsCounter.KillsCountChanged += OnKillsCountChanged;
    }


    private void OnDisable()
    {
        _killsCounter.KillsCountChanged -= OnKillsCountChanged;
    }

    private void OnKillsCountChanged(int currentValue)
    {
        OnValueChanged(currentValue, _killsCounter.MaxEnemy);
    }
}
