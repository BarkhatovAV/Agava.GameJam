using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private WeaponArmory _armory;
    [SerializeField] private Weapon _startWeapon;

    private Weapon _currentWeapon;

    private void OnValidate()
    {
        _armory = FindObjectOfType<WeaponArmory>();
    }

    private void Start()
    {
        _currentWeapon = _startWeapon;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hitInfo))
            {
                _currentWeapon.Fire(hitInfo);
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
            ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        _currentWeapon = _armory.ChangeWeapon();
    }
}
