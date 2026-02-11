using EventsForListening;
using UnityEngine;

namespace Interactions
{
    public class ItemInteraction : InteractableBase
    {
        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;
        public BoxCollider bocCollider;

        private void Awake()
        {
            if (interactionData is not BasicItemData itemData)
            {
                Debug.LogError($"{interactionData.displayName}: is not interactable itemData!");
                return;
            }

            meshFilter.sharedMesh = itemData.mesh;
            meshRenderer.sharedMaterials = itemData.materials;
            bocCollider.center = itemData.colliderCenter;
            bocCollider.size = itemData.colliderSize;
        }

        protected override void PerformInteract()
        {
            ItemEvents.RaisePickUpItem(interactionData as ItemData);
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