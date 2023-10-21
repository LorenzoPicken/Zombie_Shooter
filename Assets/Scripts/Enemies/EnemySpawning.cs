using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] bool autoSpawn;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] Transform spawnerPosition;
    [SerializeField] GameObject walkingEnemy;
    [SerializeField] GameObject runningEnemy;
    private int enemyRoll;
    private float timeSinceLastSpawn;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P) && autoSpawn == false)
        {
            SpawnEnemy();
        }
        if (autoSpawn == true)
        {
            autoEnemySpawning();
        }
        
    }
    public void SpawnEnemy()
    { 
        RandomizeEnemyType();
        if(enemyRoll == 1)
        {
            Instantiate(walkingEnemy, spawnerPosition.position, Quaternion.identity);
        }
        else
        {
            Instantiate(runningEnemy, spawnerPosition.position, Quaternion.identity);
        }
    }
    public void RandomizeEnemyType()
    {
        enemyRoll = Random.Range(1, 3);
        

    }

    public void autoEnemySpawning()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= timeBetweenSpawns)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }
}
