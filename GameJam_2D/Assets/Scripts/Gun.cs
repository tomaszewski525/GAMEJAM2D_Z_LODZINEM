using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Gun : MonoBehaviour
{
    public Transform projectileSpawn;
    public Projectile projectile;
    public float msBetweenShots = 100;
    public int burstCount;
    public PlayerMovement playerMovement;

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

            if (playerMovement.angle >= 45 && playerMovement.angle <= 135)
            {
                playerMovement.m_animator.Play("anim_shoot_backward");
            }
            else if(playerMovement.angle >= 45 && playerMovement.angle <= 135)
            {
                playerMovement.m_animator.Play("anim_shoot_right");
            }
            else if(playerMovement.angle >= -45 && playerMovement.angle < 45)
            {
                playerMovement.m_animator.Play("anim_shoot_forward");
            }
            else if(playerMovement.angle >= -45 && playerMovement.angle < 45)
            {
                playerMovement.m_animator.Play("anim_shoot_left");
            }


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