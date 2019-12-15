using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeapon : MonoBehaviour
{
    public GameObject bulletDark1Prefab;
    public Transform bulletSpawn;
    public float fireTime = 1f;
    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;

        Instantiate(bulletDark1Prefab, bulletSpawn.position, bulletSpawn.rotation);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void Shoot()
    {
        InvokeRepeating("Fire", 0.5f, fireTime);
    }

    public void Stop()
    {
        isFiring = false;
        CancelInvoke();
    }
}
