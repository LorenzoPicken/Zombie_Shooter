using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameMode currentGameMode = GameMode.PLAY;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        if(sceneIndex == 0 || sceneIndex == 1)
        {
            Debug.Log("Reseting Stats");
            Stats.ResetStats();
        }
    }

    public void SwitchGameMode(GameMode newGameMode)
    {
        currentGameMode = newGameMode;
    }
}

public enum GameMode
{
    PLAY,
    PAUSE,
    GAMEOVER
}
