using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;
using System.Runtime.CompilerServices;

public class GunBehaviour : MonoBehaviour
{
    //Gun Stats
    [SerializeField] public int bulletDamage;
    [SerializeField] public float bulletSpread;
    private float StartingBulletSpread;
    [SerializeField] public float bulletsPerTriggerPull;
    [SerializeField] public float fireCooldown;
    [SerializeField] public float range;
    [SerializeField] public float reloadTime;
    [SerializeField] public int magazineSize, bulletsPerTap;
    [SerializeField] public bool is_Automatic;
    public int bulletsShot;
    private bool isInfinite = false;

    public bool shooting, readyToShoot, reloading, isADS;

    public Camera playerCamera;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject bulletHoleGraphic;
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI text;


/* Unmerged change from project 'Assembly-CSharp.Player'
Before:
    private FPSController fpsController;


    private void Start()
After:
    private FPSController fpsController;
    private global::System.Int32 bulletsLeftInMag;

    private void Start()
*/
    private FPSController fpsController;
    private int bulletsLeftInMag;

    public int BulletsLeftInMag 
    { 
        get => bulletsLeftInMag;
        set 
        {
            if(isInfinite) return;

            bulletsLeftInMag = value; 
        }
    }

    private void Start()
    {
        StartingBulletSpread = bulletSpread;
        BulletsLeftInMag = magazineSize;
        readyToShoot = true;
        isADS = false;
        GetComponent<FPSController>();
    }


    private void Update()
    {
        //MyInput();
        if (BulletsLeftInMag == 0 && !reloading) Reload();

        //SetText
        text.SetText(BulletsLeftInMag + " / " + magazineSize);
    }

    //Handles shooting
    public void Shoot() 
    {
        if (readyToShoot && shooting && !reloading && BulletsLeftInMag > 0)
        {
            bulletsShot = bulletsPerTap;
            muzzleFlash.Play();

            readyToShoot = false;
            //Spread
            float x = Random.Range(-bulletSpread, bulletSpread);
            float y = Random.Range(-bulletSpread, bulletSpread);

            //Calculating Direction with Spread
            Vector3 direction = playerCamera.transform.forward + new Vector3(x, y, 0);

            //Raycast
            if (Physics.Raycast(playerCamera.transform.position, direction, out rayHit, range))
            {
                Vector3 hitPoint = rayHit.point;
                Vector3 surfaceNormal = rayHit.normal;

                Quaternion rotation = Quaternion.FromToRotation(hitPoint, surfaceNormal);
                Debug.Log(rayHit.transform.name);

                EnemyAttributes enemy = rayHit.transform.GetComponent<EnemyAttributes>();
                if (enemy != null) { enemy.TakeDamage(bulletDamage); }
                else { Instantiate(bulletHoleGraphic, hitPoint, rotation); }
                
            }

            
            
            //Graphics
            //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));


            BulletsLeftInMag--;
            bulletsShot--;
            Invoke("ResetShot", fireCooldown);

            if (bulletsShot > 0 && BulletsLeftInMag > 0)
            {
                Invoke("Shoot", fireCooldown);
            }
        }
    }

    //handles ADS
    public void ADS()
    {
        float CurrentSpread = bulletSpread;
        if (isADS == false && reloading == false)
        {
            isADS = true;
            CurrentSpread = bulletSpread;
            bulletSpread = 0f;
            Debug.Log("Im ADSing");
        }
        else if (isADS == true)
        {
            isADS = false;
            bulletSpread = StartingBulletSpread;
            Debug.Log("ADS off");
        }
    }
    //handles reseting shots
    private void ResetShot()
    {
        readyToShoot = true;
    }

    //Handles reloading
    public void Reload()
    {
        if (BulletsLeftInMag < magazineSize && !reloading) 
        {
            reloading = true;
            Invoke("ReloadFinished", reloadTime);
        }

    }

    public void StartInfiniteMode()
    {
        isInfinite = true;
    }

    public void StopInfiniteMode() 
    { 
        isInfinite = false;

    }


    private void ReloadFinished()
    {
        BulletsLeftInMag = magazineSize;
        reloading = false;
    }
}
