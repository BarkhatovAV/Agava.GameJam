using UnityEngine;

public static class LevelsDifficultySaver
{
    public static void SaveLevelDifficulty(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetLevelDifficulty(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
}
