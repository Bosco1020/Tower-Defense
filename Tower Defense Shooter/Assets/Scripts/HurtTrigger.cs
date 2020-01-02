using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    public int damage;
    public float resetTime = 0.25f;
    private bool contact = false;
    private void Start()
    {
        InvokeRepeating("reset", 0.1f, resetTime);
    }
    private void OnTriggerEnter2D(CircleCollider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        GetComponent<CircleCollider2D>().enabled = false;
        contact = true;
        Debug.Log("hit");
    }

    private void reset()
    {
        if (contact == true)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            Debug.Log("reset");
        }
    }
}
