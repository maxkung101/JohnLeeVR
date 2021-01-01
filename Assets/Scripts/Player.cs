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

    // Go back to the main menu
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

        if (bedroomUI.activeSelf)
        {
            bedroomUI.SetActive(false);
        }

        if (foyerUI.activeSelf)
        {
            foyerUI.SetActive(false);
        }

        if (frontYardUI.activeSelf)
        {
            frontYardUI.SetActive(false);
        }

        if (mailboxUI.activeSelf)
        {
            mailboxUI.SetActive(false);
        }

        if (tvRoomUI.activeSelf)
        {
            tvRoomUI.SetActive(false);
        }

        if (billardsRoomUI.activeSelf)
        {
            billardsRoomUI.SetActive(false);
        }

        if (kitchenUI.activeSelf)
        {
            kitchenUI.SetActive(false);
        }

        if (backyardUI.activeSelf)
        {
            backyardUI.SetActive(false);
        }

        if (phoneUI.activeSelf)
        {
            phoneUI.SetActive(false);
        }
    }

    // Go to the player's room
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

    // Answer the phone
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

    // Go to the foyer
    public void ToFoyer()
    {
        transform.position = foyer;
        AllOff();
        foyerUI.SetActive(true);
        foyerAudio.Play();
    }

    // Go to the front yard
    public void ToFrontYard()
    {
        transform.position = frontYard;
        AllOff();
        frontYardUI.SetActive(true);
        mailboxPost.GetComponent<GVRButton>().EnableButton();
        frontYardAudio.Play();
    }

    // Read mail
    public void ToMailbox()
    {
        transform.position = mailbox;
        AllOff();
        mailboxUI.SetActive(true);
    }

    // Go to the TV room
    public void ToTvRoom()
    {
        transform.position = tvRoom;
        AllOff();
        tvRoomUI.SetActive(true);
    }

    // Go to the rec room
    public void ToBillardsRoom()
    {
        transform.position = billardsRoom;
        AllOff();
        billardsRoomUI.SetActive(true);
    }

    // Go to the kitchen
    public void ToKitchen()
    {
        transform.position = kitchen;
        AllOff();
        kitchenUI.SetActive(true);
    }

    // Go to the backyard
    public void ToBackyard()
    {
        transform.position = backyard;
        AllOff();
        backyardUI.SetActive(true);
    }
}
