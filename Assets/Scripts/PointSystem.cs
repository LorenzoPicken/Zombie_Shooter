using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private int startingPoints;
    private int currentPoints;
    [SerializeField] private TextMeshProUGUI pointsDisplay;

    private void Start()
    {
        startingPoints = 0;
        currentPoints = startingPoints;
    }
    private void Update()
    {
        pointsDisplay.SetText(currentPoints.ToString());
    }

    public void GainPoints(int amount)
    {
        currentPoints += amount;
    }

    public void LosePoints(int amount)
    {
        currentPoints -= amount;
    }
    
}
