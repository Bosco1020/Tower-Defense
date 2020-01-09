using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public void Freeze()
    {
        Time.timeScale = 0.5f;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
