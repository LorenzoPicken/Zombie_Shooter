using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpProperties : MonoBehaviour
{
    [SerializeField] private float timeOnField;
    protected bool pickedUp;
    protected PowerUp powerUp;
    protected FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
        Invoke("DestroyPowerUp", timeOnField); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<FPSController>();
            ActivatePowerUp();  
        }
    }

    public abstract void ActivatePowerUp();

    private void DeactivatePowerUp()
    {
        powerUp.Deactivate();
        Destroy(gameObject);

    }

    private void DestroyPowerUp()
    {
        if (pickedUp == false)
        {
             Destroy(gameObject );
        }
    }

    private void DestroyTest()
    {
        Debug.Log("ObjectDestroyed");
        Destroy(gameObject);
    }
}
