using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private SpawnPowerUp spawnPowerUp;

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
        
        spawnPowerUp.OnSpawn();
        Destroy(this.gameObject);
    }
}
