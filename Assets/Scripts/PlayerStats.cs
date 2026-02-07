using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")] [SerializeField] private int hunger = 50;
    [SerializeField] private int maxHunger = 100;

    [Header("UI")] [SerializeField] private TextMeshProUGUI statsText; // np. "Food: 0 | HP: 100"


    private void Start()
    {
        statsText.text = $" hunger: {hunger.ToString()} / {maxHunger}";
    }

    public void AddHunger(int hungerGain = 0, string message = "")
    {
        hunger += hungerGain;
        statsText.text = $" hunger: {hunger.ToString()} / {maxHunger}";
    }
}