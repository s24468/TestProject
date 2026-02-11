using System;
using System.Collections.Generic;
using EventsForListening;
using Interactions;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] EquipmentUI equipmentUI;

    // Dictionary<Sprite,int> items =  new Dictionary<Sprite, int>();
    Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();

    private void Awake()
    {
        equipmentUI.InitializeUI(items);
    }

    private void PickUpItem(ItemData item)
    {
        AddItem(item);
        equipmentUI.ShootMessage(item.displayName);
        equipmentUI.UpdateItemsUI(items);
    }

    private void AddItem(ItemData item)
    {
        if (items.ContainsKey(item))
            items[item]++;
        else
            items[item] = 1;
    }

    private void OnEnable()
    {
        ItemEvents.OnPickUpItem += PickUpItem;
    }

    private void OnDisable()
    {
        ItemEvents.OnPickUpItem -= PickUpItem;
    }

    public void OnOpenEquipment()
    {
        if (!equipmentUI.InventoryPanel.gameObject.activeInHierarchy)
        {
            equipmentUI.InventoryPanel.gameObject.SetActive(true);
        }
        else
        {
            equipmentUI.InventoryPanel.gameObject.SetActive(false);
        }
    }
}