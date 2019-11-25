using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtTarget2D : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;
    private void Update()
    {
        if(target != null)
        {
            Vector3 difference = target.position - transform.position;
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotz + adjustmentAngle));
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
        }
    }
}
