using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerUpgrader : MonoBehaviour
{
    private Collider2D Current;
    public UnityEvent Upgrader;

    private void Start()
    {
        Current = GetComponent<Collider2D>();
    }
    public void UpgradeSelected (Collider2D other)
    {
        if (Current == other)
        {
            Upgrader.Invoke();
        }
    }
}
