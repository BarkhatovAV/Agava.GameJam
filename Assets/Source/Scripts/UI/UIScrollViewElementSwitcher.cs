using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewElementSwitcher : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollView;
    [SerializeField] private ContentSizeFitter _content;
    [SerializeField] private Button _buttonNextElement;
    [SerializeField] private Button _buttonPreviousElement;

    private float position = 0;
    private float step;


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
        _scrollView.horizontalNormalizedPosition = position;
    }

    private void OnbuttonPreviousElementClick()
    {
        position -= step;
        _scrollView.horizontalNormalizedPosition = position;
    }
}
