using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player's room coordinates
    public Vector3 mannten, moncher, sharon;

    // Area coordinates
    public Vector3 foyer, frontYard;

    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        id = PlayerPrefs.GetInt("Player Id", 0);
        ToStartingPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void ToStartingPosition()
    {
        switch(id)
        {
            case 1:
                transform.position = mannten;
                break;
            case 2:
                transform.position = moncher;
                break;
            case 3:
                transform.position = sharon;
                break;
            default:
                transform.position = mannten;
                break;
        }
    }

    public void ToFoyer()
    {
        transform.position = foyer;
    }

    public void ToFrontYard()
    {
        transform.position = frontYard;
    }
}
