using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private KillsCounter _killsCounter;

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
        int levelNumber = SceneManager.GetActiveScene().buildIndex;

        LevelsDifficultySaver.TryIncreaseLevelDifficulty(levelNumber);
    }
}
