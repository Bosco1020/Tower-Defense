using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretWeapon2 : MonoBehaviour
{
    public GameObject bulletDark1Prefab;
    public Transform bulletSpawn;
    public float fireTime = 1f;
    public UnityEvent Shooting;
    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;
        Shooting.Invoke();
        Instantiate(bulletDark1Prefab, bulletSpawn.position, bulletSpawn.rotation);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void Shoot()
    {
        InvokeRepeating("Fire", 0.7f, fireTime);
    }

    public void Stop()
    {
        isFiring = false;
        CancelInvoke();
    }
}
