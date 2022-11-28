using UnityEngine;

public class SlideBoost : Boost
{
    [SerializeField] private float _duration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerSlider slider))
        {
            slider.TakeBoost(_duration);
            OnTake();
            gameObject.SetActive(false);
        }
    }
}
