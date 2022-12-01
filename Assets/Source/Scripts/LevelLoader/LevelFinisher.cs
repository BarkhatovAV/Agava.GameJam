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
        print("here");
        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        print(levelNumber);
        LevelsDifficultySaver.TryIncreaseLevelDifficulty(levelNumber);
        print("afterTry");
        _panelLevelFinish.gameObject.SetActive(true);
        print("activated");
    }
}
