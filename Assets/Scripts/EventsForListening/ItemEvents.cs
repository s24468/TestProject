using System;
using Interactions;

namespace EventsForListening
{
    public static class ItemEvents
    {
        public static event Action<ItemData> OnPickUpItem;

        public static void RaisePickUpItem(ItemData item)
        {
            OnPickUpItem?.Invoke(item);
        }
    }
}