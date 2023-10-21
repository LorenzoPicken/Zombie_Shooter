using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxPlayerHealth;
    [SerializeField] private float regenRate;
    [SerializeField] private float timeToStartRegen;
    [SerializeField] private TextMeshProUGUI healthDisplay;
    private float timeSinceLastDamage;
    private float currentPlayerHealth;
    private Coroutine regenCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.SetText("Health: " + currentPlayerHealth.ToString());
        if(currentPlayerHealth <= 0) 
        {
            Destroy(this.gameObject);
        }
        if (Time.time - timeSinceLastDamage >= timeToStartRegen)
        {
            if (regenCoroutine == null)
            {
                regenCoroutine = StartCoroutine(RegenHealth());
            }
        }
        else if (regenCoroutine != null)
        {
            // Stop regenerating if the player takes damage
            StopCoroutine(regenCoroutine);
            regenCoroutine = null;
        }
    }
    public void PlayerTakeDamage(int amount)
    {
        currentPlayerHealth -= amount;
        timeSinceLastDamage = Time.time;
    }
    IEnumerator RegenHealth()
    {
        while (currentPlayerHealth < maxPlayerHealth)
        {
            Debug.Log("Regen Has Begun");
            currentPlayerHealth += regenRate * Time.deltaTime;
            currentPlayerHealth = Mathf.Clamp(currentPlayerHealth, 0, maxPlayerHealth);
            yield return null;
        }
    }
}
