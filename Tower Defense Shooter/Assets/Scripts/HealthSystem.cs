using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamageEvent : UnityEvent<int> {}

public class HealthSystem : MonoBehaviour
{
    public int health = 10;
    public UnityEvent onDie;
    public OnDamageEvent onDamaged;
    public int damage = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health > 0)
        {
            onDamaged.Invoke(health);
        }

        if (health < 1)
        {
            onDie.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            TakeDamage(damage);
        }
    }
}