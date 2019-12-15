using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeapon : MonoBehaviour
{
    List<GameObject> targetedEnemies;
    public GameObject bulletDark1Prefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    private GameObject target;

    void Awake()
    {
        targetedEnemies = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            targetedEnemies.Add(other.gameObject);
        }
    }

    private void Update()
    {
        foreach (GameObject target in targetedEnemies)
        {
            Fire();
        }
    }

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

        Invoke("SetFiring", fireTime);
    }

    public void Shoot()
    {
        Fire();
    }
}
