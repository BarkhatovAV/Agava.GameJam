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
    [SerializeField] private Sprite _spritePreviewLevel;
    [SerializeField] private Image _imagePreviewLevel;

    private bool _isUnlimited;

    public int Number => _levelNumber;
    public bool IsUnlimited => _isUnlimited;
    public Sprite PreviewLevel => _spritePreviewLevel;

    public event Action<UILevel> LevelSelected;


    private void Awake()
    {
        if (_levelSelector == null)
            _levelSelector = FindObjectOfType<UILevelSelector>();

        _imagePreviewLevel.sprite = _spritePreviewLevel;
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
        _buttonLevel.image.color = Color.green;
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
