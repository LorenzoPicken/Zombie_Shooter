using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private float timeBeforeRoundSpawn;
    [SerializeField] private float timeBeforeFirstRoundSpawn;
    [SerializeField] private int enemiesSpawnPerRound;
    [SerializeField] private int maxNumEnemyOnField =30;
    private float initialCountdown;
    private int enemiesSpawnedThisRound = 0;
    public static int roundNum;
    private EnemySpawnHandler enemySpawnHandler;
    private float currentTimeBeforeRound1 = 0;
    private float currentTimeBeforeRound = 0;

    private RoundState currentRoundState = RoundState.START;

    public int EnemiesSpawnedThisRound
    {
        get { return enemiesSpawnedThisRound; }
        set { enemiesSpawnedThisRound = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        enemySpawnHandler = GetComponent<EnemySpawnHandler>();
        Stats.NumEnemiesOnField = 0;
        roundNum = 0;
        initialCountdown = countdown;

    }

    // Update is called once per frame
    void Update()
    {
        if(roundNum == 0)
        {
            currentTimeBeforeRound1 += Time.deltaTime;
            
            if(currentTimeBeforeRound1 > timeBeforeFirstRoundSpawn) 
            {
                Debug.Log("Round 1 Has Begun");
                roundNum = 1;
                currentRoundState = RoundState.UPDATE;
            }
        }
        if (roundNum >= 1)
        {
            switch(currentRoundState)
            {
                case RoundState.START:
                    StartRound();
                    break;
                case RoundState.UPDATE:
                    ProgressRounds();
                    break;
                case RoundState.BETWEEN:
                    BetweenRounds();
                    break;

            }

        }
    }
    public void ProgressRounds()
    {
        if(enemiesSpawnedThisRound < enemiesSpawnPerRound && Stats.NumEnemiesOnField < maxNumEnemyOnField) 
        {
            enemySpawnHandler.Spawn();
        }
        else if(enemiesSpawnedThisRound == enemiesSpawnPerRound && Stats.NumEnemiesOnField == 0)
        {
            EndRound();
        }
    } 

    public void StartRound()
    {
        ResetValues();
        roundNum++;
        ScaleDifficulty();
        Debug.Log($"Round {roundNum} has begun");
        currentRoundState = RoundState.UPDATE;
    }
    
    public void EndRound()
    {
        Debug.Log($"Round {roundNum} has ended");
        currentRoundState = RoundState.BETWEEN;
        
    }

    public void BetweenRounds()
    {
        countdown -= 1*Time.deltaTime;
        if(countdown <= 0)
        {
            Debug.Log("Between Rounds Has Ended");
            currentTimeBeforeRound += Time.deltaTime;
            if( currentTimeBeforeRound > timeBeforeRoundSpawn )
            {
                currentRoundState = RoundState.START;
            }
        }
    }
    public void ScaleDifficulty()
    {
        if(roundNum == 1)
        {
            enemySpawnHandler.TimeBetweenSpawns = 5;
            enemySpawnHandler.MaxEnemyRoll = 2;
        }
        else if (roundNum == 2)
        {
            enemiesSpawnPerRound = 12;
            enemySpawnHandler.TimeBetweenSpawns = 5;
        }
        else if(roundNum == 3)
        {
            enemiesSpawnPerRound = 16;
            enemySpawnHandler.MaxEnemyRoll = 4;
        }
        else if(roundNum == 4)
        {
            enemiesSpawnPerRound = 20;
            enemySpawnHandler.TimeBetweenSpawns = 4.75f;
            enemySpawnHandler.MaxEnemyRoll = 5;
        }
        else if(roundNum == 5)
        {
            enemiesSpawnPerRound = 25;
            enemySpawnHandler.TimeBetweenSpawns = 4.5f;
            enemySpawnHandler.MaxEnemyRoll = 8;
        }
        else if(roundNum == 6)
        {
            enemiesSpawnPerRound = 32;
            enemySpawnHandler.TimeBetweenSpawns = 3.75f;
            enemySpawnHandler.MaxEnemyRoll = 9;
        }
        else if (roundNum == 7)
        {
            enemiesSpawnPerRound = 40;
            enemySpawnHandler.MaxEnemyRoll = 12;
        }
        else if(roundNum == 8)
        {
            enemiesSpawnPerRound = 48;
            enemySpawnHandler.TimeBetweenSpawns = 3.25f;
            enemySpawnHandler.MaxEnemyRoll = 14;
        }
        else if(roundNum == 9)
        {
            enemiesSpawnPerRound = 56;
            enemySpawnHandler.TimeBetweenSpawns = 3;
            enemySpawnHandler.MaxEnemyRoll = 16;
        }
        else if (roundNum == 10)
        {
            enemiesSpawnPerRound = 66;
            enemySpawnHandler.TimeBetweenSpawns = 2f;
        }
        else if (roundNum>10 && roundNum <= 20)
        {
            enemiesSpawnPerRound += 10;
        }
        else if (roundNum > 20)
        {
            enemiesSpawnPerRound += 15;
        }
        Debug.Log("Difficulty Has Been Scaled Up");
    }

    public void ResetValues()
    {
        enemiesSpawnedThisRound = 0;
        countdown = initialCountdown;
        currentTimeBeforeRound = 0;
        enemySpawnHandler.TimeSinceLastSpawn = 10;
        Debug.Log("Values Reset");
    }
}

public enum RoundState
{
    START,
    UPDATE,
    END,
    BETWEEN

}
