using UnityEngine;

public class StartLevelSettings : MonoBehaviour
{
    [SerializeField] private RewarderAdditionalLives _rewardAddLive;
    [SerializeField] private RewarderStartHealth _rewardStartHealth;

    private int _startHealth = 100;
    private int _livesCount = 1;
    private int _TimeBetweenSpawn;
    private bool _isUnlimited;


    private void OnEnable()
    {
        _rewardAddLive.Rewarded += AddLive;
        _rewardStartHealth.Rewarded += AddStartHelath;
    }

    private void OnDisable()
    {
        _rewardAddLive.Rewarded -= AddLive;
        _rewardStartHealth.Rewarded -= AddStartHelath;
    }

    public void StartLevel()
    {

    }

    private void AddStartHelath()
    {
        _startHealth = 150;
    }

    private void AddLive()
    {
        _livesCount = 2;
    }

    private void SetTimeBetweenspawn()
    {

    }

    private void SetUnlimitedMode(bool isUnlimited)
    {
        _isUnlimited = isUnlimited;
    }
}
