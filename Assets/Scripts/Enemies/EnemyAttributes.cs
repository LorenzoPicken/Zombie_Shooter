using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private SpawnPowerUp spawnPowerUp;
    [SerializeField] private int pointsOnDeath;
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0f)
        {
            Die();

        }
    }

    



    void Die()
    {
        Stats.GainPoints(pointsOnDeath);
        Stats.GainKills();
        spawnPowerUp.OnSpawn();
        Destroy(this.gameObject);
    }
}
