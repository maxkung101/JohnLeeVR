using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicPhone : MonoBehaviour
{
    public GameObject mic, xMic;

    // Start is called before the first frame update
    private void Start()
    {
        xMic.SetActive(false);
    }

    public void PhoneOn()
    {
        mic.SetActive(false);
        xMic.SetActive(true);
    }

    public void PhoneOff()
    {
        mic.SetActive(true);
        xMic.SetActive(false);
    }
}
