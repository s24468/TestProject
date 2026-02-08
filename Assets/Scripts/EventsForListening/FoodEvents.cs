using System;

namespace EventsForListening
{
    public static class FoodEvents
    {
        public static event Action<int, string> OnFoodEaten;

        public static void RaiseFoodEaten(int hungerGain, string foodName)
        {
            OnFoodEaten?.Invoke(hungerGain, foodName);
        }
    }
}