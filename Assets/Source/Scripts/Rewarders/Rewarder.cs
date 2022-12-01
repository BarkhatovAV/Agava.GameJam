using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class Rewarder : MonoBehaviour
{
    [SerializeField] private string _ad = "Here will be ad component";
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
        //ad component will be used here _ad.ShowVideo(OnRewarded);
        OnRewarded();
    }

    private void OnRewarded()
    {
        Rewarded?.Invoke();
        _buttonreward.interactable = false;
    }
}
