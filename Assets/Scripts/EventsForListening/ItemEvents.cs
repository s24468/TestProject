using System;
using UnityEngine;

public static class ItemEvents
{
    public static event Action<string> OnPickUpItem;

    public static void RaisePickUpItem(string item)
    {
        OnPickUpItem?.Invoke(item);
    }
}