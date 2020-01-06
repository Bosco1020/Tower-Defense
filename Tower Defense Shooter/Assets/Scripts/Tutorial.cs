using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public UnityEvent Step1, Step2, Step3, Step4, Step5, Step6;

    private int counter = -1;

    public void Tutor()
    {
        counter = counter + 1;

        if (counter == 0)
        {
            Step1.Invoke();
        }
        else if (counter == 1)
        {
            Step2.Invoke();
        }
        else if (counter == 2)
        {
            Step3.Invoke();
        }
        else if (counter == 3)
        {
            Step4.Invoke();
        }
        else if (counter == 4)
        {
            Step5.Invoke();
        }
        else if (counter == 5)
        {
            Step6.Invoke();
        }
        else if (counter > 5)
        {
            counter = 0;
        }
    }
}
