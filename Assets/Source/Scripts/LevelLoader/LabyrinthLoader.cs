using UnityEngine;
using UnityEngine.SceneManagement;

public class LabyrinthLoader : MonoBehaviour
{
    private readonly int _levelIndex = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
            SceneManager.LoadScene(_levelIndex);
    }
}