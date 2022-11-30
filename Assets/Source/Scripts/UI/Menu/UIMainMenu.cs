using UnityEngine;
using UnityEngine.UI;


public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonGameMode;
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private GameObject _panelMainMenu;
    [SerializeField] private GameObject _panelBattle;
    [SerializeField] private GameObject _panelSettings;


    private void OnEnable()
    {
        _buttonGameMode.onClick.AddListener(OnButtonGameModeClick);
        _buttonSettings.onClick.AddListener(OnButtonSettingsClick);
    }

    private void OnDisable()
    {
        _buttonGameMode.onClick.RemoveListener(OnButtonGameModeClick);
        _buttonSettings.onClick.RemoveListener(OnButtonSettingsClick);
    }

    private void OnButtonGameModeClick()
    {
        _panelMainMenu.SetActive(false);
        _panelBattle.SetActive(true);
    }

    private void OnButtonSettingsClick()
    {
        _panelMainMenu.SetActive(false);
        _panelSettings.SetActive(true);
    }
}
