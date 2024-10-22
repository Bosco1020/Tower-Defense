﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretWeapon : MonoBehaviour
{
    public GameObject bulletDark1Prefab;
    public Transform bulletSpawn;
    public float fireTime = 1f;
    public UnityEvent onShooting;
    public UnityEvent onNotShooting;
    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;
        
        onShooting.Invoke();
        Instantiate(bulletDark1Prefab, bulletSpawn.position, bulletSpawn.rotation);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void Reseting()
    {
        onNotShooting.Invoke();
    }

    public void Shoot()
    {
        InvokeRepeating("Fire", 0.5f, fireTime);
        InvokeRepeating("Reseting", 0.7f, fireTime);
    }

    public void Stop()
    {
        isFiring = false;
        CancelInvoke();
        onNotShooting.Invoke();
    }
}
