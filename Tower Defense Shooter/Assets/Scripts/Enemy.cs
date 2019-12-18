using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemySpawnedEvent : UnityEvent<Transform> { }
public class Enemy : MonoBehaviour
{
    public EnemySpawnedEvent onSpawn;
    public float range = 5f;
    public float rate = 0.5f;
    public UnityEvent ifInRange;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);
        InvokeRepeating("InRange", 0f, rate);
    }
    void InRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (distanceToPlayer <= range)
        {
            ifInRange.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
