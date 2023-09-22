using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;

public class GunBehaviour : MonoBehaviour
{
    //Gun Stats
    [SerializeField] public int bulletDamage;
    [SerializeField] public float bulletSpread;
    [SerializeField] public float bulletsPerTriggerPull;
    [SerializeField] public float fireCooldown;
    [SerializeField] public float range;
    [SerializeField] public float reloadTime;
    [SerializeField] public int magazineSize, bulletsPerTap;
    [SerializeField] public bool is_Automatic;
    int bulletsLeftInMag, bulletsShot;

    bool shooting, readyToShoot, reloading;

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


    private void Start()
    {
        bulletsLeftInMag = magazineSize;
        readyToShoot = true;
    }


    private void Update()
    {
        MyInput();

        //SetText
        text.SetText(bulletsLeftInMag + " / " + magazineSize);
    }

    //read player inputs
    private void MyInput()
    {
        if (is_Automatic == true) { shooting = Input.GetKey(KeyCode.Mouse0); }
        else { shooting = Input.GetKeyDown(KeyCode.Mouse0); }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeftInMag < magazineSize && !reloading) Reload();

        //shoot
        if (readyToShoot && shooting && !reloading && bulletsLeftInMag > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
        
    }

    

    //Handles shooting
    private void Shoot() 
    {
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

        if(bulletsShot > 0 && bulletsLeftInMag > 0)
        {
            Invoke("Shoot", fireCooldown);
        }
    }

    //handles reseting shots
    private void ResetShot()
    {
        readyToShoot = true;
    }

    //Handles reloading
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);

    }

    private void ReloadFinished()
    {
        bulletsLeftInMag = magazineSize;
        reloading = false;
    }
}
