using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private SpawnPowerUp spawnPowerUp;
    [SerializeField] private PointSystem givePoints;
    [SerializeField] private int pointsOnKill;

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
        //givePoints.GainPoints(pointsOnKill);
        Destroy(this.gameObject);
    }
}
