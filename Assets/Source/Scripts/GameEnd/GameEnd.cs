using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameEndScreenView _screenView;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _screenView.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}