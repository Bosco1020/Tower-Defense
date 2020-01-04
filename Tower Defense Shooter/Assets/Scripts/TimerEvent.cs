using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    public float time = 5, counter = 4;
    public bool repeat = false;
    public UnityEvent onTimerComplete;

    public void Start()
    {
        if(repeat)
        {
            InvokeRepeating("OnTimerComplete", 0, time);
        }
        else
        {
            Invoke("OnTimerComplete", time);
        }
    }
    private void OnTimerComplete()
    {
        onTimerComplete.Invoke();
    }

    private void countdown()
    {
        Debug.Log("yaay");
    }

}
