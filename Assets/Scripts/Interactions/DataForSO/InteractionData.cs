namespace Interactions
{
    using UnityEngine;

    public abstract class InteractionData : ScriptableObject
    {
        [Header("Identity")] public string displayName;
    }
}