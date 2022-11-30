using System;
using UnityEngine;

public static class LevelSetting
{
    private const string c_PlayerHealth = "PlayerHealth";
    private const string c_PlayerLivesCount = "PlayerLivesCount";
    private const string c_IsLevelUnlimited = "IsLevelUnlimited";

    public static int PlayerHealth
    {
        get
        {
            if (PlayerPrefs.HasKey(c_PlayerHealth))
                return PlayerPrefs.GetInt(c_PlayerHealth);
            else
                return 100;
        }
        set { PlayerPrefs.SetInt(c_PlayerHealth, value); }
    }

    public static int PlayerLivesCount
    {
        get
        {
            if (PlayerPrefs.HasKey(c_PlayerLivesCount))
                return PlayerPrefs.GetInt(c_PlayerLivesCount);
            else
                return 100;
        }
        set { PlayerPrefs.SetInt(c_PlayerLivesCount, value); }
    }

    public static bool IsUnlimited
    {
        get
        {
            if (PlayerPrefs.HasKey(c_IsLevelUnlimited))
            {
                bool isLevelUnlimited = Convert.ToBoolean(PlayerPrefs.GetString(c_IsLevelUnlimited));

                return isLevelUnlimited;
            }
            else
                return false;
        }
        set { PlayerPrefs.SetString(c_IsLevelUnlimited, value.ToString()); }
    }
}
