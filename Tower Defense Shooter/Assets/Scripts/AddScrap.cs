using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScrap : MonoBehaviour
{
    public delegate void SendScrap(int theScrap);
    public static event SendScrap OnSendScrap;

    public int scrap = 10;

    private void OnDestroy()
    {
        if (OnSendScrap != null)
        {
            OnSendScrap(scrap);
        }
    }
    public void UpdateScrap()
    {
        OnSendScrap(scrap);
    }
}
