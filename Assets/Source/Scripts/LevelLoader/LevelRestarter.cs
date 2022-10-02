using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelRestarter
{
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}