using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Player
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [Header("UI")] [SerializeField] public TextMeshProUGUI statsText; // np. "Food: 0 | HP: 100"
        [SerializeField] public TextMeshProUGUI messageText; // np. "Food: 0 | HP: 100"

        private Coroutine messageCoroutine;

        public void InitializeUI(int hunger, int maxHunger)
        {
            statsText.text = $" hunger: {hunger.ToString()} / {maxHunger}";
            if (messageText != null)
            {
                messageText.text = "";
            }
        }

        public void ChangeStats(int hunger, int maxHunger, string foodEaten)
        {
            if (messageText != null && !string.IsNullOrWhiteSpace(foodEaten))
            {
                if (messageCoroutine != null)
                    StopCoroutine(messageCoroutine);
                string message = $"{foodEaten} has been eaten!";
                messageText.text = message;
                messageCoroutine = StartCoroutine(ClearMessageAfterDelay(1f));
            }

            statsText.text = $" hunger: {hunger.ToString()} / {maxHunger}";
        }

        private IEnumerator ClearMessageAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            if (messageText != null)
            {
                messageText.text = "";
            }

            messageCoroutine = null;
        }
    }
}