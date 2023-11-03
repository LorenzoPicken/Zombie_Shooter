using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PauseMenuController pauseMenuController;
    private BasicMelee melee;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuController = GetComponent<PauseMenuController>();
        melee = GetComponent<BasicMelee>();
    }

    // Update is called once per frame
    void Update()
    {
        #region pauseMenu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuController.ToggleMenu();
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
