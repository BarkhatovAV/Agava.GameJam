using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private Button _buttonSwitchOff;
    [SerializeField] private Button _buttonSwitchOn;
    [SerializeField] private StarsDisplayer _starsDisplayer;

    private bool _isUnlimited;

    public int LevelNumber => _levelNumber;
    public bool IsUnlimited => _isUnlimited;

    private void OnEnable()
    {
        _buttonSwitchOn.onClick.AddListener(OnButtonSwitchOnClick);
        _buttonSwitchOff.onClick.AddListener(OnButtonSwitchOffClick);
    }

    private void OnDisable()
    {
        _buttonSwitchOn.onClick.RemoveListener(OnButtonSwitchOnClick);
        _buttonSwitchOff.onClick.RemoveListener(OnButtonSwitchOffClick);
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
}
