using System;
using UnityEngine;
using UnityEngine.UI;


public class UISettings : MonoBehaviour
{
    [SerializeField] private Slider _sliderMusicVolume;
    [SerializeField] private Slider _sliderEffectsVolume;
    [SerializeField] private Slider _sliderSensitivity;
    [SerializeField] private Button _buttonSwitchSoundOff;
    [SerializeField] private Button _buttonSwitchSoundOn;
    [SerializeField] private Button _buttonClose;
    [SerializeField] private GameObject _panelMainMenu;
    [SerializeField] private GameObject _panelSettings;

    private void OnEnable()
    {
        _buttonSwitchSoundOff.onClick.AddListener(OnButtonSwitchSoundOffClick);
        _buttonSwitchSoundOn.onClick.AddListener(OnButtonSwitchSoundOnClick);
        _buttonClose.onClick.AddListener(OnButtonCloseClick);
        _sliderMusicVolume.onValueChanged.AddListener(OnMusicVolumeChanged);
        _sliderEffectsVolume.onValueChanged.AddListener(OnEffectsVolumeChanged);
        _sliderSensitivity.onValueChanged.AddListener(OnSensitivityChanged);
        LoadSettings();
    }

    private void OnDisable()
    {
        _buttonSwitchSoundOff.onClick.RemoveListener(OnButtonSwitchSoundOffClick);
        _buttonSwitchSoundOn.onClick.RemoveListener(OnButtonSwitchSoundOnClick);
        _buttonClose.onClick.RemoveListener(OnButtonCloseClick);
        _sliderMusicVolume.onValueChanged.RemoveListener(OnMusicVolumeChanged);
        _sliderEffectsVolume.onValueChanged.RemoveListener(OnEffectsVolumeChanged);
        _sliderSensitivity.onValueChanged.RemoveListener(OnSensitivityChanged);
    }

    private void LoadSettings()
    {
        ChooseSoundDisplayButton();
        _sliderMusicVolume.value = SettingsSaver.MusicVolume;
        _sliderSensitivity.value = SettingsSaver.Sensitivity;
    }

    private void ChooseSoundDisplayButton()
    {
        if (SettingsSaver.AudioPause == true)
        {
            OnButtonSwitchSoundOffClick();
            _buttonSwitchSoundOn.gameObject.SetActive(true);
            _buttonSwitchSoundOff.gameObject.SetActive(false);
        }
    }

    private void OnButtonSwitchSoundOnClick()
    {
        AudioListener.pause = false;
        AudioListener.volume = SettingsSaver.MusicVolume;
        SettingsSaver.AudioPause = AudioListener.pause;
    }

    private void OnButtonSwitchSoundOffClick()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0;
        SettingsSaver.AudioPause = AudioListener.pause;
    }

    private void OnButtonCloseClick()
    {
        _panelMainMenu.SetActive(true);
        _panelSettings.SetActive(false);
    }

    private void OnMusicVolumeChanged(float value)
    {
        SettingsSaver.MusicVolume = value;
        AudioListener.volume = SettingsSaver.MusicVolume;
    }

    private void OnEffectsVolumeChanged(float value)
    {
        throw new NotImplementedException();
    }

    private void OnSensitivityChanged(float value)
    {
        SettingsSaver.Sensitivity = value;
    }
}
