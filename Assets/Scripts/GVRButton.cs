using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRButton : MonoBehaviour
{
    public Image imgCircle;
    public UnityEvent GVRClick;
    public float totalTime = 3, gvrTimer;

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

    // This method is called by the Main Camera when it starts gazing at this GameObject.
    private void OnPointerEnter()
    {
        if (isEnabled)
        {
            gvrStatus = true;
        }
    }

    // This method is called by the Main Camera when it stops gazing at this GameObject.
    private void OnPointerExit()
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
