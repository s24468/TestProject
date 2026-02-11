using UnityEngine;

namespace Interactions
{
    [CreateAssetMenu(menuName = "Interaction Data/Food Item")]
    public class FoodItemData: ItemData
    {
        
        [Header("Food Stats")]
        public int hungerGain = 15;
    }
}