using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PauseMenuController pauseMenuController;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuController = GetComponent<PauseMenuController>();
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
    }
}
