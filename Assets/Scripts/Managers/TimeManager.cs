using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
