using System;
using UnityEngine;
using System.Collections;

public class SkyView : MonoBehaviour
{
    public Material daytime, nighttime;

    private DateTime moment;
    private int hour;

    // Start is called before the first frame update
    private void Start()
    {
        moment = DateTime.Now;
        hour = moment.Hour;
        if (hour >= 6 && hour < 18)
        {
            RenderSettings.skybox = daytime;
        }
        else
        {
            RenderSettings.skybox = nighttime;
        }
    }
}
