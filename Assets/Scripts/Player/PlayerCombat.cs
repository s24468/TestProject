using UnityEngine;

public class PlayerCombat: MonoBehaviour
{
    [SerializeField] private Weapon Weapon;

    public void OnShoot()
    {
        Weapon.Shoot();
    }
}