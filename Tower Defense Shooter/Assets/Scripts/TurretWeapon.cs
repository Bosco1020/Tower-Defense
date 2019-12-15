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
        while (isFiring == true)
        {
            Instantiate(bulletDark1Prefab, bulletSpawn.position, bulletSpawn.rotation);

            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }

            Invoke("SetFiring", fireTime);
        }
    }

    public void Shoot()
    {
        isFiring = true;
        Fire();
    }

    public void Stop()
    {
        isFiring = false;
    }
}
