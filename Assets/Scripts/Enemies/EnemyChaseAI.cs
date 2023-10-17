using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseAI : MonoBehaviour
{
    [SerializeField]private NavMeshAgent enemy;
    [SerializeField] private float maxWatchSpeed;
    private Transform playerPosition;
    private GameObject Target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        Target = GameObject.Find("PlayerCapsule");
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            playerPosition = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    { 
      enemy.SetDestination(playerPosition.position);
      if(enemy.velocity.magnitude <= maxWatchSpeed) { WatchPlayer(); }
      
    }

    public void WatchPlayer()
    {
        transform.LookAt(Target.gameObject.transform);  
    }
}
