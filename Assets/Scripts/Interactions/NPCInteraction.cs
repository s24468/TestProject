using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class NPCInteraction : InteractableBase
{
    protected override void PerformInteract()
    {
        Debug.Log($"I am {Name}");
    }
}