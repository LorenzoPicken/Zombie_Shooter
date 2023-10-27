using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{

    [SerializeField] bool autoSpawn;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] Transform spawner1Position;
    [SerializeField] Transform spawner2Position;
    [SerializeField] Transform spawner3Position;
    [SerializeField] Transform spawner4Position;
    [SerializeField] Transform spawner5Position;
    [SerializeField] Transform spawner6Position;
    [SerializeField] GameObject walkingEnemy;
    [SerializeField] GameObject runningEnemy;
    private int enemyRoll;
    private int spawnerRoll;
    private float timeSinceLastSpawn;
    private int currentEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && autoSpawn == false)
        {
            RandomizeSpawner();
            if (spawnerRoll == 1)
            {
                SpawnEnemy(spawner1Position);
            }
            else if (spawnerRoll == 2)
            {
                SpawnEnemy(spawner2Position);
            }
            else if (spawnerRoll == 3)
            {
                SpawnEnemy(spawner3Position);
            }
            else if (spawnerRoll == 4)
            {
                SpawnEnemy(spawner4Position);
            }
            else if (spawnerRoll == 5)
            {
                SpawnEnemy(spawner5Position);
            }
            else if (spawnerRoll == 6)
            {
                SpawnEnemy(spawner6Position);
            }
        }
        if (autoSpawn == true)
        {
            RandomizeSpawner();
            if(spawnerRoll == 1) 
            { 
                autoEnemySpawning(spawner1Position);

            }
            else if(spawnerRoll == 2)
            {
                autoEnemySpawning(spawner2Position);
            }
            else if (spawnerRoll == 3)
            {
                autoEnemySpawning(spawner3Position);
            }
            else if (spawnerRoll == 4)
            {
                autoEnemySpawning(spawner4Position);
            }
            else if (spawnerRoll == 5)
            {
                autoEnemySpawning(spawner5Position);
            }
            else if (spawnerRoll == 6)
            {
                autoEnemySpawning(spawner6Position);
            }
        }
       
    }
    public void SpawnEnemy(Transform spawner)
    {
        RandomizeEnemyType();
        if (enemyRoll == 1)
        {
            Instantiate(walkingEnemy, spawner.position, Quaternion.identity);
        }
        else
        {
            Instantiate(runningEnemy, spawner.position, Quaternion.identity);
        }
    }
    public void RandomizeEnemyType()
    {
        enemyRoll = Random.Range(1, 3);


    }
    public void RandomizeSpawner()
    {
        spawnerRoll = Random.Range(1, 7);
    }

    public void autoEnemySpawning(Transform spawner)
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            SpawnEnemy(spawner);
            timeSinceLastSpawn = 0f;
        }
    }
}
