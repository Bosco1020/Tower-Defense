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
            
            //counter -= Time.deltaTime;

            //if (counter < 0)
            //{
                    //Invoke("OnTimerComplete", time);
                    //Invoke("CountDown", time);
                    //counter = time;
            //}
            
            //InvokeRepeating("CountDown", 0, 10f );
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

    //private void CountDown()
    //{
        //if (time > 0)
        //{
            //time = time - 1f;
        //}
    //}


}
