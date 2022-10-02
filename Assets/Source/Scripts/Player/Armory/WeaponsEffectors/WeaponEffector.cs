using UnityEngine;

public abstract class WeaponEffector : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartPlayEffects();
        if (Input.GetMouseButtonUp(0))
            StopPlayEffects();
    }

    protected abstract void StopPlayEffects();
    protected abstract void StartPlayEffects();
}
