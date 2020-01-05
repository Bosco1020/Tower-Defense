using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bulletDark1Prefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public UnityEvent Firing;

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;
        Firing.Invoke();
        Instantiate(bulletDark1Prefab, bulletSpawn.position, bulletSpawn.rotation);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("SetFiring", fireTime);
    }

    public void Shoot()
    {
        Fire();
    }
}