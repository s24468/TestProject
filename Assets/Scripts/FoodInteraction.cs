using UnityEngine;

namespace DefaultNamespace
{
    public class FoodInteraction : InteractableBase
    {
        protected override void PerformInteract()
        {
            Debug.Log($"Interact with {Name}");
        }
    }
}