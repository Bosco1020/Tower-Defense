using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    private Transform target;
    public float range = 5f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float smoothing = 5f, adjustmentAngle = 0.0f;
    public UnityEvent onTargetObtained;
    public UnityEvent onNoTarget;
    private bool stilltargeting = false;
    

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject NearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                NearestEnemy = enemy;
            }
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
        if (target == null && stilltargeting == true)
        {
            onNoTarget.Invoke();
            stilltargeting = false;
        }
        else if (target == true && stilltargeting == false)
        {
            onTargetObtained.Invoke();
            stilltargeting = true;
        }
        else if (target == null)
        {
            return;
        }

        Vector3 difference = target.position - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotz + adjustmentAngle));
        partToRotate.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);

    }
}
