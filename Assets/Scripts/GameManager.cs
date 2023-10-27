using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameMode currentGameMode = GameMode.PLAY;
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
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
