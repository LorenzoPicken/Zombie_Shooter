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
    
    /*private static List<EnemyChaseAI> enemies;

    private void OnEnable()
    {
        enemies.Add(this);
    }

    private void OnDestroy()
    {
        enemies.Remove(this);

    }*/

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
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = 0f;
        eulerAngles.z = 0f;
        transform.eulerAngles = eulerAngles;
    }
}
