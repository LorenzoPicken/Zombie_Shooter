using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private FPSController fpsController;
    private GunBehaviour gunBehaviour;
    private PauseMenuController pauseMenuController;
    private BasicMelee melee;
    // Update is called once per frame
    private void Start()
    {
        fpsController = GetComponent<FPSController>();
        gunBehaviour = GetComponent<GunBehaviour>();
        pauseMenuController = GetComponent<PauseMenuController>();
        melee = GetComponent<BasicMelee>();
        
    }
    void Update()
    {
        #region MovementInputs

        //if (Input.GetAxis("Vertical"))
        //{

        //}

        #endregion
        #region GunPlayInputs
        //Shooting when gun is automatic
        if (Input.GetKey(KeyCode.Mouse0) && gunBehaviour.is_Automatic == true) 
        {
            gunBehaviour.shooting = true;
            gunBehaviour.Shoot();
        }
        //else shooting when gun is not Automatic
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunBehaviour.shooting = true;
            gunBehaviour.Shoot();
        }

        //When shooting has stopped
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            gunBehaviour.shooting = false;
        }


        //Trigger Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            gunBehaviour.Reload();
        }

        //Trigger ADS
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            gunBehaviour.ADS();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            gunBehaviour.ADS();
        }
        #endregion
        #region Basic melee
        //When meleeing
        if (Input.GetKeyDown(KeyCode.V))
        {
            melee.meleeing = true;
            melee.Melee();
        }

        //when meleeing has stopped
        if (Input.GetKeyUp(KeyCode.V))
        {
            melee.meleeing = false;
        }
        #endregion

    }

}
