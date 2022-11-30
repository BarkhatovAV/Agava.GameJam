using UnityEngine;

public static class LevelsDifficultySaver
{
    public static void SaveLevelDifficulty(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetLevelDifficulty(string key)
    {
       if(PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetInt(key);
       else
            return 0;
    }
}
