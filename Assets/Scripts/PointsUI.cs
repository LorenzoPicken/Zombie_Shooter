using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsDisplay;
    void Awake()
    {
        Stats.onGainPoints += UpdateUI;

    }

    void UpdateUI()
    {
        pointsDisplay.text = $"Points: {Stats.Points.ToString()}";
    }
}
