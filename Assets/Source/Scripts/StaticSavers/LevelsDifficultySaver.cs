using UnityEngine;

public static class LevelsDifficultySaver
{
    private const string c_Level = "LevelDifficulty";
    private const int c_MaxDifficulty = 6;
    public static void TryIncreaseLevelDifficulty(int number)
    {
        string key = c_Level + number.ToString();
        int value = GetLevelDifficulty(number);


        if (GetLevelDifficulty(number) < c_MaxDifficulty)
        {
            value++;
            PlayerPrefs.SetInt(key, value);
        }
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
