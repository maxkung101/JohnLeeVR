﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player's room coordinates
    public Vector3 mannten, moncher, sharon;

    // Area coordinates
    public Vector3 foyer, frontYard, mailbox, tvRoom;

    // XR GUI
    public GameObject bedroomUI, foyerUI, frontYardUI, mailboxUI, tvRoomUI;

    // Mail letters
    public GameObject forMannten, forMoncher, forSharon;

    // Object teleporters
    public GameObject mailboxPost;

    // Character id
    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        forMannten.SetActive(false);
        forMoncher.SetActive(false);
        forSharon.SetActive(false);
        id = PlayerPrefs.GetInt("Player Id", 0);
        switch(id)
        {
            case 1:
                forMannten.SetActive(true);
                break;
            case 2:
                forMoncher.SetActive(true);
                break;
            case 3:
                forSharon.SetActive(true);
                break;
            default:
                forMannten.SetActive(true);
                break;
        }
        ToStartingPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void AllOff()
    {
        bedroomUI.SetActive(false);
        foyerUI.SetActive(false);
        frontYardUI.SetActive(false);
        mailboxUI.SetActive(false);
        tvRoomUI.SetActive(false);
    }

    public void ToStartingPosition()
    {
        AllOff();
        bedroomUI.SetActive(true);
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
        AllOff();
        foyerUI.SetActive(true);
        transform.position = foyer;
    }

    public void ToFrontYard()
    {
        AllOff();
        frontYardUI.SetActive(true);
        transform.position = frontYard;
        if (mailboxPost.GetComponent<BoxCollider>().enabled == false)
        {
            mailboxPost.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void ToMailbox()
    {
        AllOff();
        mailboxPost.GetComponent<BoxCollider>().enabled = false;
        mailboxUI.SetActive(true);
        transform.position = mailbox;
    }

    public void ToTvRoom()
    {
        AllOff();
        tvRoomUI.SetActive(true);
        transform.position = tvRoom;
    }
}
