using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private KillsCounter _killsCounter;
    [SerializeField] private UIPanelLevelFinish _panelLevelFinish;

    private void OnEnable()
    {
        _killsCounter.LimitReached += OnLimitReached;
    }

    private void OnDisable()
    {
        _killsCounter.LimitReached -= OnLimitReached;
    }

    private void OnLimitReached()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        LevelsDifficultySaver.TryIncreaseLevelDifficulty(levelNumber);
        _panelLevelFinish.gameObject.SetActive(true);
    }
}
