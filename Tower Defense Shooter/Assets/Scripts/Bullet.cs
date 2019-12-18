using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1000.0f;
    public int damage = 1;
    public UnityEvent OnHit;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        OnHit.Invoke();
        Die();
    }
    private void OnBecomeInvisible()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
