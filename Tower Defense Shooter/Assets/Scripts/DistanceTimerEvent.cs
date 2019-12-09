using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceTimerEvent : MonoBehaviour
{
    public float time = 5, Target = 4;
    private float Distance;
    public Transform target, self;
    public bool repeat = false;
    public UnityEvent onTimerComplete;

    public void Start()
    {
        if (repeat)
        {
            Distance = Vector3.Distance(target.position, self.position);
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

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnTimerComplete()
    {
        onTimerComplete.Invoke();
    }
}
