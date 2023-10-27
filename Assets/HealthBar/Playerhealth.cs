using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HEALTHBAR healthbar;

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

        TakeDamage(damage);
        currentHealth -= damage;
        healthbar.SetMaxHealth(currentHealth);

    }
        
}
