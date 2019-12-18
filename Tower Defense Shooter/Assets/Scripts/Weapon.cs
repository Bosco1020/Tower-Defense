using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Sprite sprite1;
    private Sprite sprite0;
    public GameObject bulletDark1Prefab;
    public Transform bulletSpawn;
    private SpriteRenderer spriteRenderer;
    public float fireTime = 0.5f;

    private bool isFiring = false, TowerSpawn = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite0 = spriteRenderer.sprite;
    }
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
        spriteRenderer.sprite = sprite1;
    }
    public void NotSpawning()
    {
        TowerSpawn = false;
        spriteRenderer.sprite = sprite0;
    }
    public void Shoot()
    {
        Fire();
    }
}
