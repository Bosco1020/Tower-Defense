using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    public float time = 5, counter = 4, delay = 5;
    public bool repeat = false, delayed = false;
    public UnityEvent onTimerComplete;

    public void Start()
    {
        if (delayed == true)
        {
            InvokeRepeating("Delay", 0, 1);
        }
        Spawn();
    }

    private void Spawn()
    {
        if (delayed == false)
        {
            if (repeat)
            {
                InvokeRepeating("OnTimerComplete", 0, time);
            }
            else
            {
                Invoke("OnTimerComplete", time);
            }
        }
        else if (delay == 0)
        {
            CancelInvoke();
            if (repeat)
            {
                InvokeRepeating("OnTimerComplete", 0, time);
            }
            else
            {
                Invoke("OnTimerComplete", time);
            }
        }
    }
    private void OnTimerComplete()
    {
        onTimerComplete.Invoke();
    }

    private void Delay()
    {
        delay = delay - 1;
        Spawn();
        
    }

    private void countdown()
    {
        Debug.Log("yaay");
    }

}
