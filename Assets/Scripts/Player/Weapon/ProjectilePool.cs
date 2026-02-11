using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [Header("Setup")] [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private int initialSize = 30;
    [SerializeField] private Transform container;

    private readonly Queue<Projectile> pool = new();

    private void Awake()
    {
        if (container == null) container = transform;

        for (int i = 0; i < initialSize; i++)
        {
            var p = CreateNew();
            Return(p);
        }
    }

    public Projectile Get()
    {
        Projectile p = pool.Count > 0 ? pool.Dequeue() : CreateNew();

        p.transform.SetParent(null, true);

        p.gameObject.SetActive(true);
        return p;
    }


    public void Return(Projectile p)
    {
        if (p == null)
        {
            return;
        }

        p.gameObject.SetActive(false);
        p.transform.SetParent(container, false);
        pool.Enqueue(p);
    }


    private Projectile CreateNew()
    {
        var p = Instantiate(projectilePrefab, container);
        p.SetPool(this);
        p.gameObject.SetActive(false);
        return p;
    }
}