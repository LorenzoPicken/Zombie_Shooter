using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp
{

    public float powerUpActiveTime = 5f;

    public abstract void Activate();

    public abstract void Deactivate();

}
