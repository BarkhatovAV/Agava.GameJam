using UnityEngine;
using UnityEngine.UI;

public class UIScrollView : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollView;
    [SerializeField] private ContentSizeFitter _content;

    float position = 0;
    private float step;

    private void Start()
    {
        print(_content.gameObject.transform.childCount);
        step = 1f/(_content.gameObject.transform.childCount - 1);
        print(step);
    }

    private void test()
    {
        position += step;
        _scrollView.horizontalNormalizedPosition = position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            test();
    }
}
