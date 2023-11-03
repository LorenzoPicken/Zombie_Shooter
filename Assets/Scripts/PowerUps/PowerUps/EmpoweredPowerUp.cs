using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmpoweredPowerUp : PowerUp
{
    GunBehaviour gunBehaviour;
    private int EmpoweredBulletsLeft;
    private int OriginalBulletsLeftInMagazine;
    FPSController fpsController;


    public EmpoweredPowerUp(FPSController fpsController)
    {
        this.fpsController = fpsController;
        powerUpActiveTime = 20;
    }
    public override void Activate()
    {
        fpsController.gunBehaviour.BulletsLeftInMag = fpsController.gunBehaviour.magazineSize;
        fpsController.gunBehaviour.StartInfiniteMode();
    }

    public override void Deactivate()
    {
        fpsController.gunBehaviour.StopInfiniteMode();
    }
}
