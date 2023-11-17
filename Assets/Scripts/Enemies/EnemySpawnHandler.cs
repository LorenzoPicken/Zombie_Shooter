using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{

    [SerializeField] bool canSpawn;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] Transform spawner1Position;
    [SerializeField] Transform spawner2Position;
    [SerializeField] Transform spawner3Position;
    [SerializeField] Transform spawner4Position;
    [SerializeField] Transform spawner5Position;
    [SerializeField] Transform spawner6Position;
    [SerializeField] EnemyAttributes walkingEnemy;
    [SerializeField] EnemyAttributes runningEnemy;
    [SerializeField] EnemyAttributes stumblingEnemy;
    private int enemyRoll;
    private int minEnemyRoll = 1;
    private int maxEnemyRoll = 3;
    private int spawnerRoll;
    private float timeSinceLastSpawn;
    private RoundManager roundManager;


    public bool CanSpawn
    {
        get { return canSpawn; }
        set { canSpawn = value; }
    }

    public float TimeBetweenSpawns
    {
        get { return timeBetweenSpawns; }
        set { timeBetweenSpawns = value; }
    }

    public int MaxEnemyRoll
    {
        get { return maxEnemyRoll; }
        set { maxEnemyRoll = value; }
    }

    public float TimeSinceLastSpawn
    {
        get { return timeSinceLastSpawn; }
        set { timeSinceLastSpawn = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        roundManager = GetComponent<RoundManager>();
    }
    public void SpawnEnemy(Transform spawner)
    {
        RandomizeEnemyType();
        if (enemyRoll >= 1 && enemyRoll <= 2)
        {
            EnemyAttributes enemy = Instantiate(stumblingEnemy, spawner.position, Quaternion.identity);
            //Increase enemy health
            enemy.health = 100 + (30 * RoundManager.roundNum);
        }
        else if (enemyRoll >= 3 && enemyRoll <= 6)
        {
            EnemyAttributes enemy = Instantiate(walkingEnemy, spawner.position, Quaternion.identity);
            //Increase enemy health
            enemy.health = 100 + (30 * RoundManager.roundNum);
        }
        else if (enemyRoll >= 7 && enemyRoll <= 15)
        {
            EnemyAttributes enemy = Instantiate(runningEnemy, spawner.position, Quaternion.identity);
            //Increase enemy health
            enemy.health = 100 + (30 * RoundManager.roundNum);
        }
    }
    public void RandomizeEnemyType()
    {
        enemyRoll = Random.Range(minEnemyRoll, maxEnemyRoll);


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
            Stats.NumEnemiesOnField++;
            roundManager.EnemiesSpawnedThisRound++;
            SpawnEnemy(spawner);
            timeSinceLastSpawn = 0f;
        }
    }
    public void Spawn()
    {
        if (canSpawn == true)
        {
            RandomizeSpawner();
            if (spawnerRoll == 1)
            {
                autoEnemySpawning(spawner1Position);

            }
            else if (spawnerRoll == 2)
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
}
