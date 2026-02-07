using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    
    HashSet<string> items = new HashSet<string>();
    private void PickUpItem(string item)
    {
        items.Add(item);
    }
    private void OnEnable()
    {
        ItemEvents.OnPickUpItem += PickUpItem;
    }
    
    private void OnDisable()
    {
        ItemEvents.OnPickUpItem -= PickUpItem;
    }

}
