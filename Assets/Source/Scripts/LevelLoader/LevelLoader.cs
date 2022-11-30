using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button _buttonBatle;
    [SerializeField] private UILevelSelector _levelSelector;

    private void OnEnable()
    {
        _buttonBatle.onClick.AddListener(OnButtonBattleClick);
    }

    private void OnDisable()
    {
        _buttonBatle.onClick.RemoveListener(OnButtonBattleClick);
    }

    private void OnButtonBattleClick()
    {
        int levelNumber = _levelSelector.Number;
        SceneManager.LoadScene(levelNumber);
    }
}
