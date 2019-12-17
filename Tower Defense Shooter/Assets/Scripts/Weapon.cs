﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletDark1Prefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;

    private bool isFiring = false, TowerSpawn = false;

    private void SetFiring()
    {
        isFiring = false;
    }
        
    private void Fire()
    {
        isFiring = true;
        Instantiate(bulletDark1Prefab, bulletSpawn.position, bulletSpawn.rotation);

        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("SetFiring", fireTime);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(!isFiring && TowerSpawn == false)
            {
                Fire();
            }
        }
    }
    public void Spawning()
    {
        TowerSpawn = true;
    }
    public void NotSpawning()
    {
        TowerSpawn = false;
    }
    public void Shoot()
    {
        Fire();
    }
}
