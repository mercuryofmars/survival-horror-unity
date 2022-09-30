using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class BFirstTrigger : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject CubeTrigger;
    public AudioSource soundTriggerB;
    public GameObject TheMarker;
    public Transform _Transform;
    public Transform Target;
    bool isTriggered = true;
    bool CameraLooksAtTable = false;


    void FixedUpdate()
    {
        if (CameraLooksAtTable == true)
        {
            _Transform.LookAt(Target);
            CameraLooksAtTable = false;
        }

    }
    void OnTriggerEnter()
    {
        if (isTriggered == true)
        {
               CameraLooksAtTable = true;
               ThePlayer.GetComponent<FirstPersonController>().enabled = false;
                StartCoroutine(ScenePlayerTriggerB());
                  isTriggered = false;
        }
    }

    IEnumerator ScenePlayerTriggerB()
    {
        soundTriggerB.Play();
        TextBox.SetActive(true);
        TextBox.GetComponent<Text>().text = "Looks like there's a weapon on that table.";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TheMarker.SetActive(true);
        CubeTrigger.SetActive(false);
    }

}
