using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceTimerEvent : MonoBehaviour
{
    public float time = 5, Target = 4.0f;
    private float Distance;
    public Transform target;
    public bool repeat = false;
    public UnityEvent onTimerComplete;

    public void Start()
    {
        if (repeat)
        {
            if (Distance < Target)
            {
                InvokeRepeating("OnTimerComplete", 0, time);
            }
        }
        else
        {
            Invoke("OnTimerComplete", time);
        }
    }

    public void Update()
    {
        Distance = Vector3.Distance(target.transform.position, transform.position);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnTimerComplete()
    {
        if (Distance < Target)
        {
            onTimerComplete.Invoke();
        }
    }
}
