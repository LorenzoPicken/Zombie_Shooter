using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{

    public void SwitchScene(int sceneIndex)
    {
        GameManager.instance.SwitchScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
