using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDie : MonoBehaviour
{
    // Start is called before the first frame update
    public void Die()
    {
        Destroy(gameObject);
    }
}
