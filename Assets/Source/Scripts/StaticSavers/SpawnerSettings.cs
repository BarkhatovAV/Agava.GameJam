using UnityEngine;

public static class SpawnerSettings
{
    private const string c_TimeBetweenSpawn = "TimeBetweenSpawn";

    public static float TimeBetweenSpawn
    {
        get
        {
            if (PlayerPrefs.HasKey(c_TimeBetweenSpawn))
                return PlayerPrefs.GetFloat(c_TimeBetweenSpawn);
            else
                return 3;
        }
        set { PlayerPrefs.SetFloat(c_TimeBetweenSpawn, value); }
    }
}
