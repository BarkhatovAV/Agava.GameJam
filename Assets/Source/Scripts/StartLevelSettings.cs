using UnityEngine;

public class StartLevelSettings : MonoBehaviour
{
    [SerializeField] private RewarderAdditionalLives _rewardAddLive;
    [SerializeField] private RewarderStartHealth _rewardStartHealth;

    private int _startHealth = 100;
    private int _livesCount = 1;

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

    private void Start()
    {
        
    }

    public void StartLevel(UILevel uiLevel)
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
}
