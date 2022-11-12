using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Gun : MonoBehaviour
{
    public Transform projectileSpawn;
    public Projectile projectile;
    public float msBetweenShots = 100;
    public int burstCount;

    private float nextShotTime;
    private int shotsRemainingInBurst;
    private bool isReloading;


    void Start()
    {
        shotsRemainingInBurst = burstCount;
    }

    void Shoot()
    {
        if (Time.time > nextShotTime && !isReloading)
        {
            if (shotsRemainingInBurst == 0)
            {
                Reload();
                return;
            }

            shotsRemainingInBurst--;
            nextShotTime = Time.time + msBetweenShots / 1000;
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Reload();
        }
    }

    public void Reload()
    {
        if (!isReloading && shotsRemainingInBurst != burstCount)
        {
            StartCoroutine(AnimateReload());
            //AudioManager.instance.PlaySound(reloadAudio, transform.position);
        }
    }

    IEnumerator AnimateReload()
    {
        isReloading = true;
        print("reloading");
        yield return new WaitForSeconds(.4f);
        isReloading = false;
        shotsRemainingInBurst = burstCount;
    }
}