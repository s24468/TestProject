using UnityEngine;

namespace DefaultNamespace
{
    public class FoodInteraction : InteractableBase
    {
        [SerializeField] private int healthGain = 15;

        protected override void PerformInteract()
        {
            //ToDo ukryta zależność (Food nie mówi, że potrzebuje PlayerStats)
            PlayerStats stats = FindFirstObjectByType<PlayerStats>();
            stats.AddHunger(healthGain);
            Debug.Log($"{Name} has been eaten!");
            Destroy(gameObject);
        }
    }
}