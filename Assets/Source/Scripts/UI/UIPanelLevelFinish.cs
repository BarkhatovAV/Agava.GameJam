using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanelLevelFinish : MonoBehaviour
{
    [SerializeField] private Button _buttonMainMenu;
    [SerializeField] private Ad _ad;

    private void OnEnable()
    {
        _buttonMainMenu.onClick.AddListener(OnButtonMainMenuClick);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _buttonMainMenu.onClick.RemoveListener(OnButtonMainMenuClick);
    }

    private void OnButtonMainMenuClick()
    {
        _ad.InterestialAdShow();
        SceneManager.LoadScene(0);
    }
}
