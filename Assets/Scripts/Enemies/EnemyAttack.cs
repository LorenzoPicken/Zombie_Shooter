using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackWindUPTime;
    [SerializeField] int attackDamage;
    private PlayerHealth player;
    private float lastAttackTime;
    private float timeSinceInRange;
    private bool isInRange;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        isInRange = false;
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not found. Make sure the player object is in the scene.");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
       

        if(distanceToPlayer <= attackRange)
        { 
            Debug.Log("In Range");
            if(!isInRange) timeSinceInRange = 0f;
            isInRange = true;
            
        }
        else
        {
            isInRange= false;
        }

        if (isInRange== true)
        {
            timeSinceInRange += Time.deltaTime;

            if(timeSinceInRange >= attackWindUPTime)
            {
                Debug.Log("Finished Winding up!");
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    player.PlayerTakeDamage(attackDamage);
                    lastAttackTime = Time.time;
                }
            }
        }
    }
    
}
