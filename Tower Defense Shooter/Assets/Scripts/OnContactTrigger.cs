using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnContactTrigger : MonoBehaviour
{
    public UnityEvent OnCollision;
    public string Target = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == Target)
        {
            OnCollision.Invoke();
        }
    }
}
