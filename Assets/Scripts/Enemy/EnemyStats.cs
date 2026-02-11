using System;
using DefaultNamespace;
using Interactions;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyStats : MonoBehaviour, IDamageable
{
    public NPCData npcData;
    public int health;

    private void Awake()
    {
        health = npcData.health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}