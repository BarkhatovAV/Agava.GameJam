using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlameThrower : Weapon, IWeapon
{
    private BulletsArmory _bullets = new BulletsArmory();
    private CapsuleCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        _bullets.AddBullets(100000);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _collider.enabled = true;

        if(Input.GetMouseButtonUp(0))
            _collider.enabled = false;
    }

    public override void Fire(Collider collider = null)
    {
        //_collider.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.Apply(_damage);
            DealingDamage(_damage);
        }
    }

    public void TakeBullets(int value)
    {
        _bullets.AddBullets(value);
    }
}
