using DG.Tweening;
using UnityEngine;

namespace Interactions
{
    public class NPCInteraction : InteractableBase
    {
        protected override void PerformInteract()
        {
            Debug.Log($"I am {interactionData.displayName}");
        }
    }
}