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
    public int bulletsLeftInMag, bulletsShot;

    public bool shooting, readyToShoot, reloading, isADS;

    public Camera playerCamera;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject bulletHoleGraphic;
    public ParticleSystem muzzleFlash;
    public CameraShake camerashake;
    public float cameraShakeMagnitude, cameraShakeDuration;
    public TextMeshProUGUI text;

    private FPSController fpsController;


    private void Start()
    {
        StartingBulletSpread = bulletSpread;
        bulletsLeftInMag = magazineSize;
        readyToShoot = true;
        isADS = false;
        GetComponent<FPSController>();
    }


    private void Update()
    {
        //MyInput();
        if (bulletsLeftInMag == 0 && !reloading) Reload();

        //SetText
        text.SetText(bulletsLeftInMag + " / " + magazineSize);
    }

    //Handles shooting
    public void Shoot() 
    {
        if (readyToShoot && shooting && !reloading && bulletsLeftInMag > 0)
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
                Debug.Log(rayHit.transform.name);

                EnemyAttributes enemy = rayHit.transform.GetComponent<EnemyAttributes>();
                if (enemy != null) { enemy.TakeDamage(bulletDamage); }
                //if (rayHit.collider.CompareTag("Enemy"))
                //rayHit.collider.GetComponent<EnemyBehaviour>().TakeDamage(bulletDamage);
            }

            //ShakeCamera
            //StartCoroutine(camerashake.CameraShaking());

            //Graphics
            Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));


            bulletsLeftInMag--;
            bulletsShot--;
            Invoke("ResetShot", fireCooldown);

            if (bulletsShot > 0 && bulletsLeftInMag > 0)
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
        if (bulletsLeftInMag < magazineSize && !reloading) 
        {
            reloading = true;
            Invoke("ReloadFinished", reloadTime);
        }

    }

    private void ReloadFinished()
    {
        bulletsLeftInMag = magazineSize;
        reloading = false;
    }
}
