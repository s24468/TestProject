using EventsForListening;
using UnityEngine;

namespace Interactions
{
    public class FoodInteraction : InteractableBase
    {
        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;
        public BoxCollider bocCollider;

        private void Awake()
        {
            if (interactionData is not ItemData foodData)
            {
                Debug.LogError($"{interactionData.displayName}: is not interactable itemData!");
                return;
            }

            meshFilter.sharedMesh = foodData.mesh;
            meshRenderer.sharedMaterials = foodData.materials;
            bocCollider.center = foodData.colliderCenter;
            bocCollider.size = foodData.colliderSize;
        }

        protected override void PerformInteract()
        {
            if (interactionData is not FoodItemData foodData)
            {
                Debug.LogError($"{name}:is not foodData!");
                return;
            }

            FoodEvents.RaiseFoodEaten(foodData.hungerGain, foodData.displayName);
            Destroy(gameObject);
        }
    }
}