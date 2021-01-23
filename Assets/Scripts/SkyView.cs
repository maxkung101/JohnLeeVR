using System;
using UnityEngine;
using System.Collections;

public class SkyView : MonoBehaviour
{
    public Material daytime, sunset, nighttime, dawn;

    private DateTime moment;
    private int hour;

    // Start is called before the first frame update
    private void Start()
    {
        moment = DateTime.Now;
        hour = moment.Hour;
        if (hour >= 9 && hour < 17)
        {
            RenderSettings.skybox = daytime;
        }
        else if (hour >= 17 && hour < 20)
        {
            RenderSettings.skybox = sunset;
        }
        else if (hour >= 20 || hour < 5)
        {
            RenderSettings.skybox = nighttime;
        }
        else
        {
            RenderSettings.skybox = dawn;
        }
    }
}
