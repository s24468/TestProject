using System;
using System.Collections;
using EventsForListening;
using Interactions.Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")] [SerializeField] private int hunger = 50;
    [SerializeField] private int maxHunger = 100;
    
    [SerializeField] PlayerStatsUI playerStatsUI;
    
    private void Start()
    {
        playerStatsUI.InitializeUI(hunger, maxHunger);
    }

    private void AddHunger(int hungerGain = 0, string foodEaten = "")
    {
        hunger = Math.Min(hunger + hungerGain, maxHunger);
        playerStatsUI.ChangeStats(hunger,maxHunger,foodEaten);
    }
    
    private void OnEnable()
    {
        FoodEvents.OnFoodEaten += AddHunger;
    }
    
    private void OnDisable()
    {
        FoodEvents.OnFoodEaten -= AddHunger;
    }
    
}
