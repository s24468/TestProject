using EventsForListening;
using UnityEngine;

namespace Interactions
{
    public class ItemInteraction : InteractableBase
    {
        protected override void PerformInteract()
        {
            ItemEvents.RaisePickUpItem(Name);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<PlayerInteractor>() == null)
            {
                return;
            }

            PerformInteract();
        }
    }
}