using UnityEngine;

namespace DefaultNamespace
{
    public class ItemInteraction : InteractableBase
    {

        protected override void PerformInteract()
        {
            ItemEvents.RaisePickUpItem(Name);
            Destroy(gameObject);
        }
    }
}