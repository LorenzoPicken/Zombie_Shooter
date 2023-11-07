using System;
using UnityEngine;
using UnityEngine.UI;

public static class Stats
{

    public static event Action onGainPoints;
    public static event Action onGainKill;

    private static int points = 0;
    private static int score = 0;
    private static int totalKills = 0;

    public static int Points
    {
        get { return points; }
        set { points = value; }
    }
    public static int Score
    {
        get { return score; }
        set { score = value; }
    }
    public static int TotalKills
    {
        get { return totalKills; }
        set { totalKills = value; }
    }

    public static void ResetStats()
    {
        points = 0;
        score = 0;
        totalKills = 0;
    }

    public static void GainPoints(int amount)
    {
        points += amount;
        score += amount;
        onGainPoints?.Invoke();
    }
    public static void GainKills()
    {
        totalKills += 1;
    }
}
