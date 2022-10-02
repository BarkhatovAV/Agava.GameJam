using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillsCounterView : MonoBehaviour
{
    [SerializeField] private SlicedFilledImage _filledImage;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private KillsCounter _killsCouner;

    private void OnValidate()
    {
        _killsCouner = FindObjectOfType<KillsCounter>();
    }

    private void OnEnable()
    {
        _killsCouner.KillsCountChanged += OnKillsCountChanged;
    }

    private void OnDisable()
    {
        _killsCouner.KillsCountChanged -= OnKillsCountChanged;
    }

    private void Awake()
    {
        _filledImage.fillAmount = 1;
    }

    private void OnKillsCountChanged(int count)
    {
        _filledImage.fillAmount = Mathf.Lerp(0f, 1f, count / _killsCouner.MaxEnemy);
        _textMesh.text = $"{count} / {_killsCouner.MaxEnemy}";
    }
}
