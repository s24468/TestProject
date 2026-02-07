using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [Header("UI")] [SerializeField] public TextMeshProUGUI itemsText; // np. "Food: 0 | HP: 100"

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


}