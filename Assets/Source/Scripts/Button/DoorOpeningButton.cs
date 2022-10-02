using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorOpeningButton : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private KillsCounter _killsCounter;

    private Animator _animator;
    private bool _limitReached;

    private void OnEnable()
    {
        _killsCounter.LimitReached += OnLimitReached;
    }

    private void OnDisable()
    {
        _killsCounter.LimitReached -= OnLimitReached;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _animator.SetTrigger(DoorOpeningButtonAnimator.Params.IsDescends);

            if (_limitReached)
                _door.Open();
            else
                _killsCounter.CounterTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _animator.SetTrigger(DoorOpeningButtonAnimator.Params.IsRises);
        }
    }

    private void OnLimitReached()
    {
        _limitReached = true;
    }
}