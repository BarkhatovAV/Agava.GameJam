using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class LevelRestarter : MonoBehaviour 
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private float _waitingTimeBeforeRestart;

    private bool _isRestartEnable;

    private void OnValidate()
    {
        _health = FindObjectOfType<PlayerHealth>();
    }

    private void Awake()
    {
        _isRestartEnable = false;
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void Update()
    {
        if(Input.anyKey && (_isRestartEnable == true))
            Restart();
    }

    private void OnDied()
    {
        StartCoroutine(WaitRestart());
    }

    public  void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator WaitRestart()
    {
        yield return new WaitForSecondsRealtime(5);

        _isRestartEnable = true;

        yield return new WaitForSecondsRealtime(_waitingTimeBeforeRestart);

        Time.timeScale = 1;

        Restart();
    }
}