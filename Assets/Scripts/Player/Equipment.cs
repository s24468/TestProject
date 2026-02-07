using System;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    [SerializeField] EquipmentUI equipmentUI;
    Dictionary<string,int> items =  new Dictionary<string, int>();

    private void Awake()
    {
        equipmentUI.UpdateItemsUI(items);
    }

    private void PickUpItem(string item)
    {
        AddItem(item);
        equipmentUI.UpdateItemsUI(items);
    }
    
    private void AddItem(string itemName)
    {
        if (items.ContainsKey(itemName))
            items[itemName]++;
        else
            items[itemName] = 1;
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
