using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Transform _screen;
    [SerializeField] private SoundMuteHandler _sound;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Start()
    {
        _sound.Stop();
        _screen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnButtonClick()
    {
        _sound.Play();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        _screen.gameObject.SetActive(false);
    }
}
