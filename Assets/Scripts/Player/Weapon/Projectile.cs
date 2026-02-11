using DefaultNamespace;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int damage = 10;
    private Rigidbody rb;
    private float lifeTimer;

    private ProjectilePool pool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetPool(ProjectilePool projectilePool)
    {
        pool = projectilePool;
    }

    public void Fire(Vector3 direction)
    {
        lifeTimer = lifetime;

        rb.linearVelocity = direction * speed;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
            Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
        }

        Disable();
    }

    private void Disable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (pool != null)
        {
            pool.Return(this);
        }
        else gameObject.SetActive(false);
    }
}