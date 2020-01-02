using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnContactTrigger : MonoBehaviour
{
    public UnityEvent OnCollision;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("oof");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("yay");
            OnCollision.Invoke();
        }
        Debug.Log("oof");
    }
}
