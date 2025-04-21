using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Gun : MonoBehaviour
{

    // Bullet
    public GameObject bulletPrefab, muzzle;
    public Animator animator;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;
    public int damage;

    // Shooting
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 0.2f;

    // Burst
    public int bulletsPerBurst = 3;
    public int currentBurst;

    // Spread
    public float spreadIntensity;

    // Shooting mode
    public Mode currentMode;

    // Gun Model
    public Model gunModel;

    // Loading
    public float reloadTime;
    public int size, bulletsLeft;
    public bool isReloading;

    // ADS
    bool isADS;

    // Initializing
    private void Awake()
    {
        readyToShoot = true;
        currentBurst = bulletsPerBurst;
        bulletsLeft = size;
        animator = GetComponent<Animator>();
        animator.keepAnimatorStateOnDisable = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // managing of switching between gun modes and ADS
        if (gunModel == Model.AK47)
        {
            if (Input.GetKeyDown(KeyCode.F) && currentMode == Mode.Auto)
            {
                currentMode = Mode.Burst;
            }
            else if (Input.GetKeyDown(KeyCode.F)) {
                currentMode = Mode.Auto;
            }

            if (Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("startADS");
                animator.ResetTrigger("endADS");
                AmmoManager.Instance.crosshair.SetActive(false);
                isADS = true;
            }
            if (isADS == true && Input.GetMouseButtonUp(1))
            {
                animator.SetTrigger("endADS");
                AmmoManager.Instance.crosshair.SetActive(true);
                isADS = false;
            }
            else if (isADS == true)
            {
                AmmoManager.Instance.crosshair.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                damage = 3000;
            }
        }
        else
        {
            AmmoManager.Instance.crosshair.SetActive(true);
        }

        // shoot when conditions are met to avoid conflicts
        if (readyToShoot && isShooting && bulletsLeft > 0 && !isReloading)
        {
            currentBurst = bulletsPerBurst;
            Shoot();
        }  

        // controlling shooting based on gun mode
        if (currentMode == Mode.Auto)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else if (currentMode == Mode.Single || currentMode == Mode.Burst)
        {
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);

        }

        // reload only when conditions are met to avoid conflicts of animations
        if ((Input.GetKeyDown(KeyCode.R) && bulletsLeft < size && isReloading == false && gunModel != Model.Bat)
        || (Input.GetKeyDown(KeyCode.Mouse0) && bulletsLeft == 0 && isReloading == false && gunModel != Model.Bat))
        {
            Reload();
        }

        // swing when gun model is bat
        if (isShooting && gunModel == Model.Bat)
        {
            Swing();
        }
    }

    // Gun modes
    public enum Mode
    {
        Single, Burst, Auto
    }

    // Weapon models
    public enum Model
    {
        Pistol, AK47, Bat
    }

    // Basic Shoot Function
    public void Shoot()
    {
        bulletsLeft--;

        muzzle.GetComponent<ParticleSystem>().Play();

        if (isADS)
            animator.SetTrigger("RecoilADS");
        else
            animator.SetTrigger("Recoil");

        readyToShoot = false;

        SoundManager.Instance.shootingSound.Play();

        // Normalized vector with only directions
        Vector3 shootingDirection = DirectionAndSpread().normalized;

        // Spawn bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        // Assign damage to bullet
        Bullet b = bullet.GetComponent<Bullet>();
        b.damage = damage;

        // Face bullet to shooting direction
        bullet.transform.forward = shootingDirection;

        // Add force to bullet
        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);

        // Destroy bullet corr. to lifetime
        StartCoroutine(DestroyBullet(bullet, bulletPrefabLifeTime));

        // Check if finish shooting
        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }

        // Burst Mode calculation
        if (currentMode == Mode.Burst && currentBurst > 1)
        {
            currentBurst--;
            Invoke("Shoot", shootingDelay);
        }
    }

    // Bat Swing 
    public void Swing()
    {
        BatManager.Instance.Attack();
        int random = UnityEngine.Random.Range(1, 3);
        if (random == 1)
            animator.SetTrigger("Recoil");
        else
            animator.SetTrigger("Recoil_alt");

        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }
    }

    // Reset bools after each shot
    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    // Gun reload function
    private void Reload()
    {
        isReloading= true;
        if (isADS)
            animator.SetTrigger("ReloadADS");
        else
            animator.SetTrigger("Reload");
        Invoke("ReloadCompleted", reloadTime);
    }

    // Reset no of bullets after reloading is completed
    private void ReloadCompleted()
    {
        bulletsLeft = size;
        isReloading = false;
    }

    // Return Vector3 of bullet's direction and magnitude of spreading
    public Vector3 DirectionAndSpread()
    {
        // Shooting from middle of screen to check pointing direction
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            // Hit something
            targetPoint = hit.point;
        }
        else
        {
            // Shooting at nothing e.g. air
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - bulletSpawn.position;

        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        // return shooting direction and spread of bullets
        return direction + new Vector3(x, y, 0);
    }

    //Destroy bullet function
    private IEnumerator DestroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
