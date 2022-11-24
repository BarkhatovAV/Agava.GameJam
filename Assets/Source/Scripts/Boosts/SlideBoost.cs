using UnityEngine;

public class SlideBoost : MonoBehaviour
{
    [SerializeField] private float _duration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerSlider slider))
        {
            slider.TakeBoost(_duration);
            gameObject.SetActive(false);
        }
    }
}
