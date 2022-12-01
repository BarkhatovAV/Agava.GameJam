using System;
using UnityEngine;

public static class SettingsSaver
{
    private const string c_Sound = "Sound";
    private const string c_MusicVolume = "MusicVolume";
    private const string c_EffectsVolume = "EffectsVolume";
    private const string c_Sensitivity = "Sensitivity";


    public static bool AudioPause
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Sound))
            {
                bool isLevelUnlimited = Convert.ToBoolean(PlayerPrefs.GetString(c_Sound));

                return isLevelUnlimited;
            }
            else
                return false;
        }
        set { PlayerPrefs.SetString(c_Sound, value.ToString()); }
    }

    public static float MusicVolume
    {
        get
        {
            if (PlayerPrefs.HasKey(c_MusicVolume))
                return PlayerPrefs.GetFloat(c_MusicVolume);
            else
                return 1;
        }
        set { PlayerPrefs.SetFloat(c_MusicVolume, value); }
    }

    public static float EffectsVolume
    {
        get
        {
            if (PlayerPrefs.HasKey(c_EffectsVolume))
                return PlayerPrefs.GetFloat(c_EffectsVolume);
            else
                return 1;
        }
        set { PlayerPrefs.SetFloat(c_EffectsVolume, value); }
    }

    public static float Sensitivity
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Sensitivity))
                return PlayerPrefs.GetFloat(c_Sensitivity);
            else
                return 100;
        }
        set { PlayerPrefs.SetFloat(c_Sensitivity, value); }
    }
}
