using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPicksUpKey : MonoBehaviour
{
    public GameObject FirstRoomKey;
    public GameObject KeyTrigger;
    public GameObject ButtonText, DisplayActionText, ExtraCrosshair;
    public AudioSource PicksKeySound;
    int counter = 0;
    public static bool keyTrigger = false;
    public static bool isPlayerHoldingKey = false; 

    void Update()

    {
        if (Input.GetButtonDown("Action") && keyTrigger == true && counter == 0)
        {
            ButtonText.SetActive(false);
            DisplayActionText.SetActive(false);
            ExtraCrosshair.SetActive(false);
            PicksKeySound.Play();
            FirstRoomKey.SetActive(false);
            isPlayerHoldingKey = true;
            counter++;
        }

    } // end for void update

    void OnTriggerEnter()
    {
        if (counter == 0)
        {
            keyTrigger = true;
            ButtonText.SetActive(true);
            DisplayActionText.SetActive(true);
            DisplayActionText.GetComponent<Text>().text = "Pick the key";
            ExtraCrosshair.SetActive(true);
        }

    }


    void OnTriggerExit()
    {
        keyTrigger = false;
        ButtonText.SetActive(false);
        DisplayActionText.SetActive(false);
        ExtraCrosshair.SetActive(false);
        if (counter > 0)
        {
            isPlayerHoldingKey = true;
        }
    }


    
}
