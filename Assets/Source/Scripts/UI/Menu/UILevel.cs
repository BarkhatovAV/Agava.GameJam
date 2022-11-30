using System;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private Button _buttonSwitchOff;
    [SerializeField] private Button _buttonSwitchOn;
    [SerializeField] private StarsDisplayer _starsDisplayer;
    [SerializeField] private Button _buttonLevel;
    [SerializeField] private UILevelSelector _levelSelector;

    private bool _isUnlimited;

    public int LevelNumber => _levelNumber;
    public bool IsUnlimited => _isUnlimited;

    public event Action<UILevel> LevelSelected;

    private void Awake()
    {
        if (_levelSelector == null)
            _levelSelector = FindObjectOfType<UILevelSelector>();
    }

    private void OnEnable()
    {
        _buttonSwitchOn.onClick.AddListener(OnButtonSwitchOnClick);
        _buttonSwitchOff.onClick.AddListener(OnButtonSwitchOffClick);
        _buttonLevel.onClick.AddListener(OnButtonLevelClick);
        _levelSelector.NewLevelSelected += OnNewLevelSelected;
    }

    private void OnDisable()
    {
        _buttonSwitchOn.onClick.RemoveListener(OnButtonSwitchOnClick);
        _buttonSwitchOff.onClick.RemoveListener(OnButtonSwitchOffClick);
        _buttonLevel.onClick.RemoveListener(OnButtonLevelClick);
        _levelSelector.NewLevelSelected -= OnNewLevelSelected;
    }

    private void Start()
    {
        int levelDiufficulty = LevelsDifficultySaver.GetLevelDifficulty(_levelNumber);

        _starsDisplayer.SetDisplayingCountStars(levelDiufficulty);
    }

    private void OnButtonSwitchOnClick()
    {
        _isUnlimited = true;
        print(_isUnlimited);
    }

    private void OnButtonSwitchOffClick()
    {
        _isUnlimited = false;
        print(_isUnlimited);
    }

    private void OnButtonLevelClick()
    {
        LevelSelected?.Invoke(this);
        _buttonLevel.image.color = Color.yellow;
    }

    private void OnNewLevelSelected(UILevel uiLevel)
    {
        TryDeselectLevel(uiLevel);
    }

    private void TryDeselectLevel(UILevel uiLevel)
    {
        if (uiLevel != this)
            _buttonLevel.image.color = Color.white;
    }
}
