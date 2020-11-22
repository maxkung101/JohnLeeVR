using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicPhone : MonoBehaviour
{
    private Vector3 activePosition, inactivePosition;
    private Quaternion activeRotation, inactiveRotation;

    // Start is called before the first frame update
    private void Start()
    {
        inactivePosition = transform.position;
        inactiveRotation = transform.rotation;
        activePosition = new Vector3(transform.position.x + 11.05f, transform.position.y + 4.6383f, transform.position.z + 15.83f);
        activeRotation = Quaternion.Euler(transform.rotation.x + 90f, transform.rotation.y + 180f, transform.rotation.z);
    }

    public void PhoneOn()
    {
        transform.position = activePosition;
        transform.rotation = activeRotation;
    }

    public void PhoneOff()
    {
        transform.position = inactivePosition;
        transform.rotation = inactiveRotation;
    }
}
