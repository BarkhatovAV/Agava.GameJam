using UnityEngine;
using UnityEngine.UI;

public class UILoadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panelLoading;
    [SerializeField] private Image _imageLevelPreview;
    [SerializeField] private UILevelSelector _levelSelector;
    [SerializeField] private LevelLoader _loader;

    private void Start()
    {
        _panelLoading.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _loader.LevelLoadStarted += OnLevelLoadStarted;
    }

    private void OnDisable()
    {
        _loader.LevelLoadStarted -= OnLevelLoadStarted;
    }

    private void OnLevelLoadStarted()
    {
        _panelLoading.SetActive(true);
        _imageLevelPreview.sprite = _levelSelector.SelectedLevel.PreviewLevel;
    }
}
