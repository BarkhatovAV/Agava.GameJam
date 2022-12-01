using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UILevelSelector : MonoBehaviour
{
    [SerializeField] private List<UILevel> _uiLevels;

    private UILevel _selectedLevel;

    public int Number => _selectedLevel.Number;
    public event Action<UILevel> NewLevelSelected;

    private void OnEnable()
    {
        for (int i = 0; i < _uiLevels.Count; i++)
            _uiLevels[i].LevelSelected += OnLevelSelected;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _uiLevels.Count; i++)
            _uiLevels[i].LevelSelected -= OnLevelSelected;
    }

    private void OnLevelSelected(UILevel uiLevel)
    {
        _selectedLevel = uiLevel;
        NewLevelSelected?.Invoke(uiLevel);
    }

}
