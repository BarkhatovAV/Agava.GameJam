using UnityEngine;

public abstract class WeaponAnimator : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartAnimation();
        if (Input.GetMouseButtonUp(0))
            StopAnimation();
    }

    protected abstract void StopAnimation();
    protected abstract void StartAnimation();

}
