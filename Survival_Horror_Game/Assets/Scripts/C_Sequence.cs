using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Sequence : MonoBehaviour
{
    public GameObject CSeqeunceTrigger;
    public GameObject FirstDoor;
    public AudioSource SoundFirstDoorCloses;
    bool startTrigger = false;
    public static bool DoorIsClosed = false;
    int counter = 0;

    void Update()
    {
        if (PistolTrigger.SequenceCTrigger == true)
        {
            startTrigger = true;
            PistolTrigger.SequenceCTrigger = false;

        }
    }

    void OnTriggerEnter()
    {
        if (startTrigger == true && counter == 0)
        {
            counter++;
            CSeqeunceTrigger.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine((TimingDoorClosing()));
        }

    }

    IEnumerator TimingDoorClosing()
    {
        FirstDoor.GetComponent<Animation>().Play("FirstDoorCloseAnim");
        yield return new WaitForSeconds(0.68f);
        SoundFirstDoorCloses.Play();
        DoorIsClosed = true;

    }

    void OnTriggerExit()
    {
        startTrigger = false;
    }
}
