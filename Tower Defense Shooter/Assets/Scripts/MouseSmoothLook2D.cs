﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSmoothLook2D : MonoBehaviour
{
    public Camera theCamera;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;
    

    void Update()
    {
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;

        difference.Normalize();

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotz + adjustmentAngle));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
    }
}
