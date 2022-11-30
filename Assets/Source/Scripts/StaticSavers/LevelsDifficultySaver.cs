using UnityEngine;

public static class LevelsDifficultySaver
{
    private const string c_Level = "LevelDifficulty";

    public static void IncreaseLevelDifficulty(int number)
    {
        string key = c_Level + number.ToString();
        int value = GetLevelDifficulty(number) + 1;

        PlayerPrefs.SetInt(key, value);
    }

    public static int GetLevelDifficulty(int number)
    {
        string key = c_Level + number.ToString();

       if(PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetInt(key);
       else
            return 0;
    }
}
