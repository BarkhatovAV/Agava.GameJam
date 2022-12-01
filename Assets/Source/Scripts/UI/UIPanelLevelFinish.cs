using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanelLevelFinish : MonoBehaviour
{
    [SerializeField] private Button _buttonMainMenu;

    private void OnEnable()
    {
        _buttonMainMenu.onClick.AddListener(OnButtonMainMenuClick);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _buttonMainMenu.onClick.RemoveListener(OnButtonMainMenuClick);
    }

    private void OnButtonMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
