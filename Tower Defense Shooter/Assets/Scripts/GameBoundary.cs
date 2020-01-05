using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBoundary : MonoBehaviour
{
    private Transform target;
    public GameObject enemy;
    public float range = 25f;
    public UnityEvent onOutOfBounds, onReturn;
    private bool waiting = false;
    private GameObject NearestEnemy = null;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    void UpdateTarget()
    {
         float shortestDistance = Mathf.Infinity;
         float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
        distanceToEnemy = distanceToEnemy - 78;
         if (distanceToEnemy < shortestDistance)
         {
                shortestDistance = distanceToEnemy;
                NearestEnemy = enemy;
         }

        if (NearestEnemy != null && shortestDistance <= range)
        {
            target = NearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Update()
    {
        if (target == null && waiting == false)
        {
            onOutOfBounds.Invoke();
            waiting = true;
        }
        else if (target != null && waiting == true)
        {
            onReturn.Invoke();
            waiting = false;
        }
        else return;
    }
}
