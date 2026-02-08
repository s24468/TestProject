using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [Header("UI")] [SerializeField] public TextMeshProUGUI itemsText;
    [SerializeField] private MessageQueueUI messageQueue;

    public void InitializeUI(Dictionary<string, int> items)
    {
        UpdateItemsUI(items);
    }

    public void UpdateItemsUI(Dictionary<string, int> items)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Items:");
        foreach (var kvp in items)
        {
            sb.AppendLine($"{kvp.Key} x{kvp.Value}");
        }

        itemsText.text = sb.ToString();
    }

    public void ShootMessage(string itemName)
    {
        messageQueue.EnqueueMessage($"You picked up {itemName}!");
    }
}