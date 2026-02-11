using System.Collections;
using System.Collections.Generic;
using System.Text;
using Interactions;
using Interactions.Player;
using TMPro;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [Header("UI")] //[SerializeField] public TextMeshProUGUI itemsText;
    [SerializeField] private MessageQueueUI messageQueue;
    [SerializeField] public Transform InventoryPanel;
    [SerializeField] private Transform itemContainer;
    [SerializeField] private GameObject slotPrefab;

    public void InitializeUI(Dictionary<ItemData, int> items)
    {
        UpdateItemsUI(items);
    }
    public void UpdateItemsUI(Dictionary<ItemData, int> items)
    {
        // wyczyść stare sloty
        foreach (Transform child in itemContainer)
            Destroy(child.gameObject);

        foreach (var kvp in items)
        {
            Debug.Log($"{kvp.Key.displayName}: {kvp.Value}");
            var slot = Instantiate(slotPrefab, itemContainer);
            var slotUI = slot.GetComponent<InventorySlotUI>();

            slotUI.Setup(kvp.Key.icon, kvp.Value);
        }
    }

    public void ShootMessage(string itemName)
    {
        messageQueue.EnqueueMessage($"You picked up {itemName}!");
    }
}