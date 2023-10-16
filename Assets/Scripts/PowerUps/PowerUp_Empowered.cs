using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Empowered : PowerUpProperties
{
    public override void ActivatePowerUp()
    {
        pickedUp = true;

        powerUp = new EmpoweredPowerUp(player);
        powerUp.Activate();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Invoke("DeactivatePowerUp", powerUp.powerUpActiveTime);
    }
}
