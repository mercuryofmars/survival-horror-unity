using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolTrigger : MonoBehaviour
{
    public float TheDistance;
    public static bool playerPickedThePistol = false;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject ExtraCross;
    public GameObject GuidedArrow;
    public GameObject TorchB_Loom;
    public GameObject TorchB_Particals;
    public AudioSource clip, clip2, clip3, clip4, clip5;
    public GameObject ZombieDoorTrigger;
    public GameObject ZombieCharacter;
    public GameObject DoorTriggerCollider;

    bool PistolCubeTrigger;
    public static bool SequenceCTrigger;
    int counter = 0;

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
        if (Input.GetButtonDown("Action") && PistolCubeTrigger == true && counter < 1) // "Action" is defined within unity and corresponds to 'e' key.
        {
            counter++;
            clip.Play();
            StartCoroutine(DoorKnockSounds());
            playerPickedThePistol = true;
            this.GetComponent<BoxCollider>().enabled = false; // this reffers to the object this script is attached to.
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            FakePistol.SetActive(false);
            RealPistol.SetActive(true);
            ExtraCross.SetActive(false);
            GuidedArrow.SetActive(false);
            SequenceCTrigger = true; // C sequence will start

            StartCoroutine(ZombieScene());
        }
        if (ZombieDeath.ZombieHealthStatus == false)
        {
            clip5.Stop();
            clip4.Stop();
        }

    }

    void OnTriggerEnter()
    {
        ExtraCross.SetActive(true);
        ActionDisplay.SetActive(true); // showing the text - e
        ActionText.GetComponent<Text>().text = "Pick up the Pistol";
        ActionText.SetActive(true);

    }

    void OnTriggerStay()
    {

        PistolCubeTrigger = true;

    }

    void OnTriggerExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    /* void OnMouseOver() //whenever the mouse passes over the object that this script will be attached to.
     {
         if (TheDistance <= 0.4)
         {
             ExtraCross.SetActive(true);
             ActionDisplay.SetActive(true); // showing the text - e
             ActionText.GetComponent<Text>().text = "Pick up the Pistol";
             ActionText.SetActive(true);

         }

         if (Input.GetButtonDown("Action")) // "Action" is defined within unity and corresponds to 'e' key.
         {
             if (TheDistance <= 0.4)
             {
                 clip.Play();
                 StartCoroutine(DoorKnockSounds());
                 this.GetComponent<BoxCollider>().enabled = false; // this reffers to the object this script is attached to.
                 ActionDisplay.SetActive(false);
                 ActionText.SetActive(false);
                 FakePistol.SetActive(false);
                 RealPistol.SetActive(true);
                 ExtraCross.SetActive(false);
                 GuidedArrow.SetActive(false);
                 StartCoroutine(ZombieScene());
             }
         }
     }
    */

    /*  private void OnMouseExit() // when we're not looking at the door - opposite of OnMouseOver
      {
          ExtraCross.SetActive(false);
          ActionDisplay.SetActive(false);
          ActionText.SetActive(false);
      }
    */
    IEnumerator DoorKnockSounds()
    {
        yield return new WaitForSeconds(1.05f);
        clip2.Play();
        TorchB_Loom.SetActive(false);
        TorchB_Particals.SetActive(false);
    }

    IEnumerator ZombieScene()
    {
        yield return new WaitForSeconds(2f);
        clip3.Play();
        yield return new WaitForSeconds(1f);
        ZombieDoorTrigger.GetComponent<Animation>().Play("ZombieDoorAnimation");
        ZombieCharacter.SetActive(true);
        DoorTriggerCollider.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        if (ZombieDeath.ZombieHealthStatus == true) // Zombie enters door ambiance music
        {
            clip4.Play();
            clip5.Play();

        }

    }



}
