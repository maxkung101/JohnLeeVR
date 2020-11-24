using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Telephone : MonoBehaviour
{
    public GameObject hub1, hub2, hub3;
    public Material newMaterialOn, newMaterialOff;
    public AudioClip audioClip;

    private PlayerControls controls;
    private AudioSource source;
    private bool isRinging, isActive;
    private string selectedDevice;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Call.started += ctx => SpaceBar();
    }

    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
        isRinging = false;
        isActive = false;
        selectedDevice = Microphone.devices[0].ToString();
    }

    private void CallPhone()
    {
        isRinging = true;
        source.Play();
        hub1.GetComponent<Renderer>().material = newMaterialOn;
        hub2.GetComponent<Renderer>().material = newMaterialOn;
        hub3.GetComponent<Renderer>().material = newMaterialOn;
    }

    private void CancelCall()
    {
        isRinging = false;
        source.Stop();
        hub1.GetComponent<Renderer>().material = newMaterialOff;
        hub2.GetComponent<Renderer>().material = newMaterialOff;
        hub3.GetComponent<Renderer>().material = newMaterialOff;
    }

    private void SpaceBar()
    {
        if (!isActive)
        {
            if (isRinging)
            {
                CancelCall();
            }
            else
            {
                CallPhone();
            }
        }
    }

    public void AnswerPhone()
    {
        isActive = true;
        if (isRinging)
        {
            isRinging = false;
            source.Stop();
        }
        hub1.GetComponent<Renderer>().material = newMaterialOn;
        hub2.GetComponent<Renderer>().material = newMaterialOn;
        hub3.GetComponent<Renderer>().material = newMaterialOn;
        source.clip = Microphone.Start(selectedDevice, true, 10, AudioSettings.outputSampleRate);
        source.Play();
    }

    public void HangUp()
    {
        isActive = false;
        hub1.GetComponent<Renderer>().material = newMaterialOff;
        hub2.GetComponent<Renderer>().material = newMaterialOff;
        hub3.GetComponent<Renderer>().material = newMaterialOff;
        source.clip = audioClip;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}