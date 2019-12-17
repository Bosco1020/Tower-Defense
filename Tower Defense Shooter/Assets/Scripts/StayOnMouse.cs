using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 10f;
    void Start()
    {
        
    }
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
