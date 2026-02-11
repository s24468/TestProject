namespace Interactions
{
    using UnityEngine;

    public class ItemData : InteractionData
    {
        [Header("Identity")]
        public string itemId;

        [Header("Visuals")]
        public Mesh mesh;
        public Material[] materials;
        public Vector3 visualScale = Vector3.one;

        [Header("Pickup Collider")]
        public Vector3 colliderCenter = Vector3.zero;
        public Vector3 colliderSize = Vector3.one;
        
        [Header("Optional UI")]
        public Sprite icon;
    }
}