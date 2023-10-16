using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    private int randomNumber;
    [SerializeField] private int minRange, maxRange;
    [SerializeField] private GameObject marathonPrefab, empoweredPrefab;
    private Vector3 spawnPosition;
    
    public void OnSpawn()
    {
        
        spawnPosition = transform.position;
        randomNumber = Random.Range(minRange, maxRange);
        if (randomNumber == 1)
        {
            Instantiate(marathonPrefab, spawnPosition, Quaternion.identity);
        }
        else if (randomNumber == 2)
        {
            Instantiate(empoweredPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
