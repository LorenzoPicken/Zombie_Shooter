using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMelee : MonoBehaviour
{
    [SerializeField] private float meleeDamage;
    [SerializeField] private float meleeCooldown;
    [SerializeField] private float meleeRange;
    public bool readyToMelee, meleeing;

    public RaycastHit rayHit;
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        readyToMelee = true;
        meleeing = false;
       
    }

    public void Melee()
    {
        if (readyToMelee && meleeing) 
        {
            readyToMelee = false;

            Vector3 direction = playerCamera.transform.forward;
            //Raycast
            if(Physics.Raycast(playerCamera.transform.position, direction, out rayHit, meleeRange))
            {
                Debug.Log(rayHit.transform.name);

                EnemyAttributes enemy = rayHit.transform.GetComponent<EnemyAttributes>();
                if ((enemy != null)){ enemy.TakeDamage(meleeDamage); }
                
            }

            Invoke("ResetMelee", meleeCooldown);
        }
    }
    private void ResetMelee()
    {
        readyToMelee = true;
    }
}
