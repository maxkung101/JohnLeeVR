using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour
{
    private AudioSource source;
    private bool isRinging, isActive;

    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
        isRinging = false;
        isActive = false;
    }

    public bool PhoneRinging()
    {
        return isRinging;
    }

    public bool PhoneActive()
    {
        return isActive;
    }

    public void CallPhone()
    {
        isRinging = true;
        source.Play();
    }

    public void CancelCall()
    {
        isRinging = false;
        source.Stop();
    }

    public void AnswerPhone()
    {
        isActive = true;
        if (isRinging)
        {
            isRinging = false;
            source.Stop();
        }
    }

    public void HangUp()
    {
        isActive = false;
    }
}