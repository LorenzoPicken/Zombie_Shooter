using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingPlayerHealth;
    public float currentPlayerHealth;
    public
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerHealth = startingPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayerHealth <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
