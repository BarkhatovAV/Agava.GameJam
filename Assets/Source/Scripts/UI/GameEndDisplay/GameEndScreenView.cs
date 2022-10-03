using UnityEngine;
using UnityEngine.UI;

public class GameEndScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}