using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;

    void start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
       
    }

    void TakeDamage(int damage)
    {

        TakeDamage
        currentHealth -= damage;
        healthbar.SetMaxHealth(currentHealth);

    }
        
}
