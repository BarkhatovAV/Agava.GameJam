using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewElementSwitcher : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollView;
    [SerializeField] private ContentSizeFitter _content;
    [SerializeField] private Button _buttonNextElement;
    [SerializeField] private Button _buttonPreviousElement;
    [SerializeField] private float _speed;

    private float position = 0;
    private float step;
    private Coroutine _coroutine;


    private void OnEnable()
    {
        _buttonNextElement.onClick.AddListener(OnButtonNextElementClick);
        _buttonPreviousElement.onClick.AddListener(OnbuttonPreviousElementClick);
    }

    private void OnDisable()
    {
        _buttonNextElement.onClick.AddListener(OnButtonNextElementClick);
        _buttonPreviousElement.onClick.AddListener(OnbuttonPreviousElementClick);
    }

    private void Start()
    {
        step = 1f / (_content.gameObject.transform.childCount - 1);
    }

    private void OnButtonNextElementClick()
    {
        position += step;
        StartMove();
    }

    private void OnbuttonPreviousElementClick()
    {
        position -= step;
        StartMove();
    }

    private void MoveView()
    {
        _scrollView.horizontalNormalizedPosition = Mathf.Lerp(_scrollView.horizontalNormalizedPosition, position, _speed * Time.deltaTime);
    }

    private void StartMove()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnMoveView());
    }

    private IEnumerator OnMoveView()
    {
        while (_scrollView.horizontalNormalizedPosition != position)
        {
            MoveView();
            yield return new WaitForSeconds(0.01f);
        }
    }
}
