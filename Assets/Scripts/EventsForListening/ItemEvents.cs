using System;

namespace EventsForListening
{
    public static class ItemEvents
    {
        public static event Action<string> OnPickUpItem;

        public static void RaisePickUpItem(string item)
        {
            OnPickUpItem?.Invoke(item);
        }
    }
}