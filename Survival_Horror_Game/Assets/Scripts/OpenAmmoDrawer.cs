using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenAmmoDrawer : MonoBehaviour
{
    //UI
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    //Drawer Opening Sound
    public AudioSource DrawerOpeningSound;
    public AudioSource PlayerPickedAmmo;
    //Drawer Ammo GameObject
    public GameObject DrawerAmmo;
    public GameObject DrawerAmmoTriggerCube;
    // Ammo GameOject
    public GameObject Ammo;
    //Logic
    public static bool playerIsIndrawerTrigger = false;
    public static bool playerPickedAmmo = false;
    public static int currentAmmo = 0;
    bool playerIsInAmmoTrigger = false;
    bool playerOpenedDraw = false;
    int counter = 0;

    void Update()
    {
        if (Input.GetButtonDown("Action") && playerIsIndrawerTrigger == true && counter == 0)
        {
            counter++;
            playerOpenedDraw = true;
            DrawerAmmo.GetComponent<Animation>().Play("AmmoRightDrawerOpen");
            // DrawerAmmoTriggerCube.GetComponent<BoxCollider>().enabled = false;
            DrawerOpeningSound.Play();
            ExtraCross.SetActive(false);
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            playerIsIndrawerTrigger = false;
        }

       else if (Input.GetButtonDown("Action") && PistolTrigger.playerPickedThePistol == true && playerIsInAmmoTrigger == true && counter == 1)
        {
            counter++;
            playerPickedAmmo = true;
            currentAmmo += 5;
            PlayerPickedAmmo.Play();
            Ammo.SetActive(false);
            ExtraCross.SetActive(false);
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            playerIsInAmmoTrigger = false;
            DrawerAmmoTriggerCube.SetActive(false);
        }
    }

    void OnTriggerEnter()
    {
        if (counter < 1)
        {
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true); // showing the text - e
            ActionText.GetComponent<Text>().text = "Open the drawer";
            ActionText.SetActive(true); // showing the text - explanation
        }

        if (PistolTrigger.playerPickedThePistol == true && playerOpenedDraw == true && counter ==1)
        {
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true); // showing the text - e
            ActionText.GetComponent<Text>().text = "Pick 5 bullets";
            ActionText.SetActive(true); // showing the text - explanation
        }

    }

    void OnTriggerStay()
    {
        playerIsIndrawerTrigger = true;
        playerIsInAmmoTrigger = true;
        if (PistolTrigger.playerPickedThePistol == true && playerOpenedDraw == true && counter == 1)
        {
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true); // showing the text - e
            ActionText.GetComponent<Text>().text = "Pick 5 bullets";
            ActionText.SetActive(true); // showing the text - explanation

        }

    }

    void OnTriggerExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        playerIsIndrawerTrigger = false;
        playerIsInAmmoTrigger = false;
    }
}
