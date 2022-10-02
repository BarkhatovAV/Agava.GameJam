using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _clonesCount;

    public int ClonesCount => _clonesCount;
    public bool Deactivated => gameObject.activeSelf == false;

    public void Activate() => gameObject.SetActive(true);

    public void Deactivate() => gameObject.SetActive(false);
}