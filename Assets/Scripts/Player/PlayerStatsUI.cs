using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactions.Player
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [Header("UI")] [SerializeField] public TextMeshProUGUI statsText; // np. "Food: 0 | HP: 100"
        [SerializeField] private MessageQueueUI messageQueue;

        public void InitializeUI(int hunger, int maxHunger)
        {
            statsText.text = $" hunger: {hunger.ToString()} / {maxHunger}";
        }

        public void ChangeStats(int hunger, int maxHunger, string foodEaten)
        {
            if (!string.IsNullOrWhiteSpace(foodEaten))
            {
                messageQueue.EnqueueMessage($"{foodEaten} has been eaten!");
            }

            statsText.text = $" hunger: {hunger} / {maxHunger}";
        }
    }
}