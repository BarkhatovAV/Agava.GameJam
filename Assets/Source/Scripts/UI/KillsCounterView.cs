using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillsCounterView : MonoBehaviour
{
    [SerializeField] private SlicedFilledImage _filledImage;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private KillsCounter _killsCouner;
    [SerializeField] private Animator _animator;

    private string _pulseAnimation = "Pulse";

    private void OnValidate()
    {
        _killsCouner = FindObjectOfType<KillsCounter>();
    }

    private void OnEnable()
    {
        _killsCouner.KillsCountChanged += OnKillsCountChanged;
        _killsCouner.CounterTriggered += OnCounterTriggered;
    }

    private void OnDisable()
    {
        _killsCouner.KillsCountChanged -= OnKillsCountChanged;
        _killsCouner.CounterTriggered -= OnCounterTriggered;
    }

    private void OnCounterTriggered()
    {
        _animator.SetTrigger(_pulseAnimation);
    }

    private void Awake()
    {
        _filledImage.fillAmount = 0;
    }

    private void OnKillsCountChanged(int count)
    {
        _filledImage.fillAmount = Mathf.Lerp(0f, 1f, count / _killsCouner.MaxEnemy);
        _textMesh.text = $"{count} / {_killsCouner.MaxEnemy}";
    }
}
