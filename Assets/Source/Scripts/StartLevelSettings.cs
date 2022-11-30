using System;
using UnityEngine;

public class StartLevelSettings : MonoBehaviour
{
    [SerializeField] private RewarderAdditionalLives _rewardAddLive;
    [SerializeField] private RewarderStartHealth _rewardStartHealth;
    [SerializeField] private UILevelSelector _levelSelector;

    private int _startHealth = 100;
    private int _livesCount = 1;

    private void OnEnable()
    {
        _rewardAddLive.Rewarded += AddLive;
        _rewardStartHealth.Rewarded += AddStartHelath;
        _levelSelector.NewLevelSelected += OnNewLevelSelected;
    }

    private void OnDisable()
    {
        _rewardAddLive.Rewarded -= AddLive;
        _rewardStartHealth.Rewarded -= AddStartHelath;
        _levelSelector.NewLevelSelected -= OnNewLevelSelected;
    }

    private void Start()
    {
        LevelSetting.PlayerHealth = _startHealth;
        LevelSetting.PlayerLivesCount = _livesCount;
    }

    private void OnNewLevelSelected(UILevel uiLevel)
    {
        LevelSetting.IsUnlimited = uiLevel.IsUnlimited;
    }

    private void AddStartHelath()
    {
        _startHealth = 150;
        LevelSetting.PlayerHealth = _startHealth;
    }

    private void AddLive()
    {
        _livesCount = 2;
        LevelSetting.PlayerLivesCount = _livesCount;
    }
}
