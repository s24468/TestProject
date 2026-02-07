using System;

public static class FoodEvents
{
    // kto zjadł (opcjonalnie), ile, nazwa/ID
    public static event Action<int, string> OnFoodEaten;

    public static void RaiseFoodEaten(int hungerGain, string foodName)
    {
        OnFoodEaten?.Invoke(hungerGain, foodName);
    }
}