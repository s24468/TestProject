using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")] [SerializeField] private int hunger = 50;
    [SerializeField] private int maxHunger = 100;

    [Header("UI")] [SerializeField] private TextMeshProUGUI statsText; // np. "Food: 0 | HP: 100"
    [SerializeField] private TextMeshProUGUI messageText; // np. "Food: 0 | HP: 100"

    private Coroutine messageCoroutine;

    private void Start()
    {
        statsText.text = $" hunger: {hunger.ToString()} / {maxHunger}";
        if (messageText != null)
        {
            messageText.text = "";
        }
    }

    private IEnumerator ClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (messageText != null)
            messageText.text = "";

        messageCoroutine = null;
    }

    public void AddHunger(int hungerGain = 0, string foodEaten = "")
    {
        hunger += hungerGain;
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
}