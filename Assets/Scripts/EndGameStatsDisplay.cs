using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameStatsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI killsDisplay;

    void Start()
    {
        scoreDisplay.text = $"Score: {Stats.Score.ToString()}";
        killsDisplay.text = $"Kills: {Stats.TotalKills.ToString()}";
    }
    private void Update()
    {
        
    }
}
