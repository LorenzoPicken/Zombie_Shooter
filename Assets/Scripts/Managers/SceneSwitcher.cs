using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{

    public void SwitchScene(int sceneIndex)
    {
        if(sceneIndex == 0 || sceneIndex ==1)
        {
            Stats.ResetPoints();
        }
        GameManager.instance.SwitchScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
