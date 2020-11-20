using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Player's room coordinates
    public Vector3 mannten, moncher, sharon;

    // Player's phone coordinates
    public Vector3 manntenPhone, moncherPhone, sharonPhone;

    // Area coordinates
    public Vector3 foyer, frontYard, mailbox, tvRoom, billardsRoom, kitchen, backyard;

    // XR GUI
    public GameObject bedroomUI, foyerUI, frontYardUI, mailboxUI, tvRoomUI, billardsRoomUI, kitchenUI, backyardUI, phoneUI;

    // Mail letters
    public GameObject forMannten, forMoncher, forSharon;

    // Object teleporters
    public GameObject mailboxPost, manntenHub, moncherHub, sharonHub, pc1, pc2, pc3;

    // Audio objects
    public GameObject johnToMannten, johnToMoncher, johnToSharon, johnInFrontYard;

    // Audio sources
    private AudioSource foyerAudio, frontYardAudio;

    // Character id
    private int id;

    // Start is called before the first frame update
    private void Start()
    {
        forMannten.SetActive(false);
        forMoncher.SetActive(false);
        forSharon.SetActive(false);
        id = PlayerPrefs.GetInt("John Lee VR - Player Id", 0);
        switch(id)
        {
            case 1:
                forMannten.SetActive(true);
                foyerAudio = johnToMannten.GetComponent<AudioSource>();
                break;
            case 2:
                forMoncher.SetActive(true);
                foyerAudio = johnToMoncher.GetComponent<AudioSource>();
                break;
            case 3:
                forSharon.SetActive(true);
                foyerAudio = johnToSharon.GetComponent<AudioSource>();
                break;
            default:
                forMannten.SetActive(true);
                foyerAudio = johnToMannten.GetComponent<AudioSource>();
                break;
        }
        frontYardAudio = johnInFrontYard.GetComponent<AudioSource>();
        ToStartingPosition();
    }

    public void HomeClick()
    {
        PlayerPrefs.SetInt("John Lee VR - Player Id", 0);
        SceneManager.LoadScene("MainMenu");
    }

    private void AllOff()
    {
        if (mailboxPost.GetComponent<GVRButton>().GetButtonStats())
        {
            mailboxPost.GetComponent<GVRButton>().DisableButton();
        }

        if (pc1.GetComponent<GVRButton>().GetButtonStats())
        {
            pc1.GetComponent<GVRButton>().DisableButton();
        }

        if (pc2.GetComponent<GVRButton>().GetButtonStats())
        {
            pc2.GetComponent<GVRButton>().DisableButton();
        }

        if (pc3.GetComponent<GVRButton>().GetButtonStats())
        {
            pc3.GetComponent<GVRButton>().DisableButton();
        }

        if (manntenHub.GetComponent<GVRButton>().GetButtonStats())
        {
            manntenHub.GetComponent<GVRButton>().DisableButton();
        }

        if (moncherHub.GetComponent<GVRButton>().GetButtonStats())
        {
            moncherHub.GetComponent<GVRButton>().DisableButton();
        }

        if (sharonHub.GetComponent<GVRButton>().GetButtonStats())
        {
            sharonHub.GetComponent<GVRButton>().DisableButton();
        }

        if (bedroomUI.active)
        {
            bedroomUI.SetActive(false);
        }

        if (foyerUI.active)
        {
            foyerUI.SetActive(false);
        }

        if (frontYardUI.active)
        {
            frontYardUI.SetActive(false);
        }

        if (mailboxUI.active)
        {
            mailboxUI.SetActive(false);
        }

        if (tvRoomUI.active)
        {
            tvRoomUI.SetActive(false);
        }

        if (billardsRoomUI.active)
        {
            billardsRoomUI.SetActive(false);
        }

        if (kitchenUI.active)
        {
            kitchenUI.SetActive(false);
        }

        if (backyardUI.active)
        {
            backyardUI.SetActive(false);
        }

        if (phoneUI.active)
        {
            phoneUI.SetActive(false);
        }
    }

    public void ToStartingPosition()
    {
        AllOff();
        bedroomUI.SetActive(true);
        switch(id)
        {
            case 1:
                transform.position = mannten;
                pc1.GetComponent<GVRButton>().EnableButton();
                manntenHub.GetComponent<GVRButton>().EnableButton();
                break;
            case 2:
                transform.position = moncher;
                pc2.GetComponent<GVRButton>().EnableButton();
                moncherHub.GetComponent<GVRButton>().EnableButton();
                break;
            case 3:
                transform.position = sharon;
                pc3.GetComponent<GVRButton>().EnableButton();
                sharonHub.GetComponent<GVRButton>().EnableButton();
                break;
            default:
                transform.position = mannten;
                pc1.GetComponent<GVRButton>().EnableButton();
                manntenHub.GetComponent<GVRButton>().EnableButton();
                break;
        }
    }

    public void ToPhone()
    {
        AllOff();
        phoneUI.SetActive(true);
        switch(id)
        {
            case 1:
                transform.position = manntenPhone;
                break;
            case 2:
                transform.position = moncherPhone;
                break;
            case 3:
                transform.position = sharonPhone;
                break;
            default:
                transform.position = manntenPhone;
                break;
        }
    }

    public void ToFoyer()
    {
        transform.position = foyer;
        AllOff();
        foyerUI.SetActive(true);
        foyerAudio.Play();
    }

    public void ToFrontYard()
    {
        transform.position = frontYard;
        AllOff();
        frontYardUI.SetActive(true);
        mailboxPost.GetComponent<GVRButton>().EnableButton();
        frontYardAudio.Play();
    }

    public void ToMailbox()
    {
        transform.position = mailbox;
        AllOff();
        mailboxUI.SetActive(true);
    }

    public void ToTvRoom()
    {
        transform.position = tvRoom;
        AllOff();
        tvRoomUI.SetActive(true);
    }

    public void ToBillardsRoom()
    {
        transform.position = billardsRoom;
        AllOff();
        billardsRoomUI.SetActive(true);
    }

    public void ToKitchen()
    {
        transform.position = kitchen;
        AllOff();
        kitchenUI.SetActive(true);
    }

    public void ToBackyard()
    {
        transform.position = backyard;
        AllOff();
        backyardUI.SetActive(true);
    }
}
