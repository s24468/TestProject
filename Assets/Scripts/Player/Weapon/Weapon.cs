using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private ProjectilePool pool;

    public void Shoot()
    {
        Projectile proj = pool.Get();

        proj.transform.position = firePoint.position;
        proj.transform.rotation = firePoint.rotation;

        proj.Fire(firePoint.forward);
    }
}
