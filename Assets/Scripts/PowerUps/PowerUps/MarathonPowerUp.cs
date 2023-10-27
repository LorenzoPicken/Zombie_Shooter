using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarathonPowerUp: PowerUp
{
    private float marathonWalkSpeed = 14f;
    private float marathonSprintSpeed = 14f;
    private float originalWalkSpeed, originalSprintSpeed;
    FPSController fpsController;

    public MarathonPowerUp(FPSController fpsController)
    {
        this.fpsController = fpsController;
        originalWalkSpeed = fpsController.walkSpeed; 
        originalSprintSpeed = fpsController.runSpeed;
        powerUpActiveTime = 15f;        
    }

    public override void Activate()
    {
        fpsController.walkSpeed = marathonWalkSpeed; fpsController.runSpeed = marathonSprintSpeed;
    }
    public override void Deactivate()
    {
        fpsController.walkSpeed = originalWalkSpeed;
        fpsController.runSpeed = originalSprintSpeed;
        Debug.Log("Deactivate");

    }
}
