using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRButton : MonoBehaviour
{
    public Image imgCircle;
    public UnityEvent GVRClick;
    public float totalTime = 3;
    public float gvrTimer;

    private bool gvrStatus, isEnabled;

    // Start is called before the first frame update
    private void Start()
    {
        gvrStatus = false;
        isEnabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgCircle.fillAmount = gvrTimer / totalTime;
        }

        if (gvrTimer > totalTime)
        {
            GVRClick.Invoke();
            gvrStatus = false;
            gvrTimer = 0;
            imgCircle.fillAmount = 0;
        }
    }

    public void OnPointerEnter()
    {
        if (isEnabled)
        {
            gvrStatus = true;
        }
    }

    public void OnPointerExit()
    {
        if (isEnabled)
        {
            gvrStatus = false;
            gvrTimer = 0;
            imgCircle.fillAmount = 0;
        }
    }

    public bool GetButtonStats()
    {
        return isEnabled;
    }

    public void DisableButton()
    {
        isEnabled = false;
    }

    public void EnableButton()
    {
        isEnabled = true;
    }
}
