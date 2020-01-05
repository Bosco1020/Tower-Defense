using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    public float counter = 11;
    private bool Continue = false;
    public UnityEvent DuringCountdown, OnCountdownComplete, OnCountdownCancelled;

    private void Timer()
    {
        counter = counter - 1;
    }

    private void Update()
    {
        
        if (counter == 0 && Continue == false)
        {
            Reseter();
            OnCountdownComplete.Invoke();
            Time.timeScale = 0f;
        }

        else if (Continue == true)
        {
            Reseter();
        }
        else return;
    }

    public void Counting()
    {
        DuringCountdown.Invoke();
        InvokeRepeating("Timer", 1, 1);
    }

    public void Stop()
    {
        OnCountdownCancelled.Invoke();
        Continue = true;
    }

    private void Reseter()
    {
        counter = 11;
        Continue = false;
        CancelInvoke();
    }
}
