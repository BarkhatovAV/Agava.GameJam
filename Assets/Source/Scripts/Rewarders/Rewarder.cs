using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class Rewarder : MonoBehaviour
{
    [SerializeField] private Ad _ad;
    [SerializeField] private Button _buttonreward;

    public event Action Rewarded;

    private void OnEnable()
    {
        _buttonreward.onClick.AddListener(OnButtonRewardedClick);
    }

    private void OnDisable()
    {
        _buttonreward.onClick.RemoveListener(OnButtonRewardedClick);
    }

    private void OnButtonRewardedClick()
    {
        _ad.ShowRewardVideo(OnRewarded);
    }

    private void OnRewarded()
    {
        Rewarded?.Invoke();
        _buttonreward.interactable = false;
    }
}
