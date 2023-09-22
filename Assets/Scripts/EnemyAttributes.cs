using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public float health = 100f;

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
        Destroy(gameObject);
    }
}
