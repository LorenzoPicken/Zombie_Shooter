using System;
using UnityEngine;
using UnityEngine.UI;

public static class Stats
{

    public static event Action onGainPoints;

    private static int points = 0;

    public static int Points
    {
        get { return points; }
        set { points = value; }
    }

    public static void ResetPoints()
    {
        points = 0;
    }

    public static void GainPoints(int amount)
    {
        points += amount;
        onGainPoints?.Invoke();
    }
}
