using UnityEngine;

namespace DefaultNamespace
{
    public class FoodInteraction : InteractableBase
    {
        [SerializeField] private int hungerGain = 15;

        protected override void PerformInteract()
        {
            FoodEvents.RaiseFoodEaten(hungerGain, Name);
            Destroy(gameObject);
        }
    }
}