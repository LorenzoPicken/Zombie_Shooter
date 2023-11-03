using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class Stats
{

    public static event Action onGainPoints;

    private static int points = 0;

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


public class PointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsDisplay;
    void Awake()
    {
        Stats.onGainPoints += UpdateUI;

    }

    void UpdateUI()
    {
        //Update UI Logic
    }

}
