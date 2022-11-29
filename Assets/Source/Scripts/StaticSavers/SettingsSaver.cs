using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsSaver
{
    private const string c_Sound = "Sound";
    private const string c_Volume = "Volume";
    private const string c_Sensitivity = "Sensitivity";


    public static int AudioPause
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Sound))
                return PlayerPrefs.GetInt(c_Sound);
            else
                return 1;
        }
        set { PlayerPrefs.SetInt(c_Sound, value); }
    }

    public static float Volume
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Volume))
                return PlayerPrefs.GetFloat(c_Volume);
            else
                return 1;
        }
        set { PlayerPrefs.SetFloat(c_Volume, value); }
    }

    public static float Sensitivity
    {
        get
        {
            if (PlayerPrefs.HasKey(c_Sensitivity))
                return PlayerPrefs.GetFloat(c_Sensitivity);
            else
                return 1;
        }
        set { PlayerPrefs.SetFloat(c_Sensitivity, value); }
    }
}
