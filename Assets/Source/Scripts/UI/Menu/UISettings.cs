using System;
using UnityEngine;
using UnityEngine.UI;


public class UISettings : MonoBehaviour
{
    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private Slider _sliderSensitivity;
    [SerializeField] private Button _buttonSwitchSoundOff;
    [SerializeField] private Button _buttonSwitchSoundOn;
    [SerializeField] private Button _buttonClose;

    private void OnEnable()
    {
        _buttonSwitchSoundOff.onClick.AddListener(OnButtonSwitchSoundOffClick);
        _buttonSwitchSoundOn.onClick.AddListener(OnButtonSwitchSoundOnClick);
        _sliderVolume.onValueChanged.AddListener(OnVolumeChanged);
        _sliderSensitivity.onValueChanged.AddListener(OnSensitivityChanged);
        LoadSettings();
    }

    private void OnDisable()
    {
        _buttonSwitchSoundOff.onClick.RemoveListener(OnButtonSwitchSoundOffClick);
        _buttonSwitchSoundOn.onClick.RemoveListener(OnButtonSwitchSoundOnClick);
        _sliderVolume.onValueChanged.RemoveListener(OnVolumeChanged);
        _sliderSensitivity.onValueChanged.AddListener(OnSensitivityChanged);
    }

    private void LoadSettings()
    {
        ChooseSoundDisplayButton();
        _sliderVolume.value = SettingsSaver.Volume;
        _sliderSensitivity.value = SettingsSaver.Sensitivity;
    }

    private void ChooseSoundDisplayButton()
    {
        if (SettingsSaver.AudioPause == 1)
            OnButtonSwitchSoundOffClick();
    }

    private void OnButtonSwitchSoundOnClick()
    {
        AudioListener.pause = false;
        AudioListener.volume = SettingsSaver.Volume;
        SettingsSaver.AudioPause = 0;
    }

    private void OnButtonSwitchSoundOffClick()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0;
        SettingsSaver.AudioPause = 1;
    }

    private void OnVolumeChanged(float value)
    {
        SettingsSaver.Volume = value;
        AudioListener.volume = SettingsSaver.Volume;
    }

    private void OnSensitivityChanged(float value)
    {
        SettingsSaver.Sensitivity = value;
    }
}
