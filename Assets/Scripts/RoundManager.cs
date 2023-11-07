using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private int maxNumEnemyOnField;
    [SerializeField] private int minEnemyRoll;
    [SerializeField] private int maxEnemyRoll;
    [SerializeField] private float timeBetweenRounds;
    [SerializeField] private float timeBeforeRound1Spawn;
    [SerializeField] private int enemiesSpawnPerRound;
    private int numEnemyOnField;
    private static int roundNum;
    private bool inRound;


    // Start is called before the first frame update
    void Start()
    {
        numEnemyOnField = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ResetValues()
    {

    }

    enum ImportantRounds
    {
        ROUND1,
        ROUND5,
        ROUND10,
        ROUND15,
        ROUND20
    }
}
