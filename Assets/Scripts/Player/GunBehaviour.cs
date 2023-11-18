using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class GunBehaviour : MonoBehaviour
{
    //Gun Stats
    [SerializeField] public int bulletDamage;
    private int currentBulletDamage;
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

    private FPSController fpsController;
    private int bulletsLeftInMag;

    //recoil
    private WeaponRecoil recoil;

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
        fpsController = GetComponent<FPSController>();
        recoil = GetComponent<WeaponRecoil>();
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
            //Making sure each new bullet starts at full damage
            currentBulletDamage = bulletDamage;
            recoil.ApplyRecoil();

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

                EnemyAttributes enemy = rayHit.transform.GetComponent<EnemyAttributes>();
                if (enemy != null) 
                { 
                    enemy.TakeDamage(currentBulletDamage);
                    Debug.Log("Enemy Hit For " + currentBulletDamage);

                    // Reduce bullet damage for penetration
                    currentBulletDamage = Mathf.Max(1, Mathf.RoundToInt(currentBulletDamage * 0.75f));

                    // Continue the raycast
                    direction = hitPoint - playerCamera.transform.position;

                }
                else 
                { 
                    Instantiate(bulletHoleGraphic, hitPoint, rotation);
                    Debug.Log(rayHit.transform.name);
                }
                
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
        if (isADS == false)
        {
            isADS = true;
            CurrentSpread = bulletSpread;
            bulletSpread = 0f;
        }
        else if (isADS == true)
        {
            isADS = false;
            bulletSpread = StartingBulletSpread;
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
