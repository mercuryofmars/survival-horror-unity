using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorOpen : MonoBehaviour
{
    public GameObject KeyActionText, ExplainText, ActionCrosshair, PlayerTalksText, HoldToUnlockDoorIcon, HoldToUnlockDoorIcon2, HoldToUnlockDoorIcon3;
    public GameObject FirstRoomDoorHinge, DoorTrigger, Player;
    public AudioSource DoorOpensCreaky, PlayerUnlockingDoor;
    bool doorHasOpened = false;
    bool playerIsInDoorTrigger = false;
    bool isPlayerTalking = false;
    float timer = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Action") && doorHasOpened == false) // First Room Scene - Press 'E' to open door
        {
            if (playerIsInDoorTrigger == true && PlayerPicksUpKey.isPlayerHoldingKey == true)
            {
                doorHasOpened = true;
                DoorTrigger.GetComponent<BoxCollider>().enabled = false;
                // disabling UI
                playerIsInDoorTrigger = false;
                KeyActionText.SetActive(false);
                ExplainText.SetActive(false);
                ActionCrosshair.SetActive(false);
                // end UI
                StartCoroutine(FirstRoomDoorOpening());
            }

            else if (playerIsInDoorTrigger == true && PlayerPicksUpKey.isPlayerHoldingKey == false && isPlayerTalking == false)
            {
                StartCoroutine(PlayerTextTalk());
            }
        }
        // ------------------------------------------------------------------------------------------------------------------------------------------------
        if (Input.GetButton("Action") && C_Sequence.DoorIsClosed == true && playerIsInDoorTrigger == true) //Hold 'E' to open door (getbuttondown didn't progressively change timer. C seqeunce related
        {

            if (PlayerUnlockingDoor.isPlaying == false)
            {
                PlayerUnlockingDoor.Play();

            }
        }
            if (Input.GetButton("Action") && C_Sequence.DoorIsClosed == true && playerIsInDoorTrigger == true) //Hold 'E' to open door (getbuttondown didn't progressively change timer. C seqeunce related
        {
            PlayerTalksText.GetComponent<Text>().text = "Trying to unlock the door";

            // timing 3 seconds
            timer += Time.deltaTime;

            if (timer >= 0f && timer <= 1f)
            {
                HoldToUnlockDoorIcon.SetActive(true);
            }
            if (timer >= 1f && timer <= 2f)
            {
                HoldToUnlockDoorIcon2.SetActive(true);
            }
            if (timer >= 2f && timer <= 3f)
            {
                HoldToUnlockDoorIcon3.SetActive(true);
            }
            if (timer >= 3f)
            {
                StartCoroutine(UnlockingDoorCSequence());
            }
        }
        if (Input.GetButtonUp("Action") && C_Sequence.DoorIsClosed == true || C_Sequence.DoorIsClosed == true &&  playerIsInDoorTrigger == false) // second half in order to prevent player pre-pressing action key to unlock door
        {
            timer = 0f;
            PlayerUnlockingDoor.Stop();
            PlayerTalksText.GetComponent<Text>().text = "";
            HoldToUnlockDoorIcon.SetActive(false);
            HoldToUnlockDoorIcon2.SetActive(false);
            HoldToUnlockDoorIcon3.SetActive(false);
        }
        // ------------------------------------------------------------------------------------------------------------------------------------------------

    }

    void OnTriggerEnter()
    {
        playerIsInDoorTrigger = true;
        KeyActionText.SetActive(true);
        ExplainText.SetActive(true);
        ActionCrosshair.SetActive(true);
        ExplainText.GetComponent<Text>().text = "Open door";
    }

    void OnTriggerExit()
    {
        playerIsInDoorTrigger = false;
        KeyActionText.SetActive(false);
        ExplainText.SetActive(false);
        ActionCrosshair.SetActive(false);
    }

    IEnumerator FirstRoomDoorOpening()
    {
        DoorOpensCreaky.Play();
        FirstRoomDoorHinge.GetComponent<Animation>().Play("FirstDoorOpenAnim");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator PlayerTextTalk()
    {
        isPlayerTalking = true;
        PlayerTalksText.GetComponent<Text>().text = "I need to find its key";
        yield return new WaitForSeconds(2f);
        PlayerTalksText.GetComponent<Text>().text = "";
        isPlayerTalking = false;
    }

    IEnumerator UnlockingDoorCSequence()
    {
        // UI
        KeyActionText.SetActive(false);
        ExplainText.SetActive(false);
        ActionCrosshair.SetActive(false);
        PlayerTalksText.GetComponent<Text>().text = "";
        // end of UI

        DoorTrigger.GetComponent<BoxCollider>().enabled = false;
        C_Sequence.DoorIsClosed = false;

        PlayerUnlockingDoor.Stop();
        DoorOpensCreaky.Play();
        FirstRoomDoorHinge.GetComponent<Animation>().Play("FirstDoorOpenAnim");
        HoldToUnlockDoorIcon.SetActive(false);
        HoldToUnlockDoorIcon2.SetActive(false);
        HoldToUnlockDoorIcon3.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }
}
