using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private FPSController fpsController;
    private bool is_Paused = false;

   
    public void ToggleMenu()
    {
        is_Paused = !is_Paused;
        if (is_Paused)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }
    public void OpenMenu()
    {
        timeManager.Pause();
        fpsController.canMove = false;
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.instance.SwitchGameMode(GameMode.PAUSE);
        
    }
    public void CloseMenu()
    {
        timeManager.Resume();
        fpsController.canMove = true; ;
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.instance.SwitchGameMode(GameMode.PLAY);
    }
    public void Resume()
    {

    }
}
