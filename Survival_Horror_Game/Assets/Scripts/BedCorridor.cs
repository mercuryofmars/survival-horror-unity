using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class BedCorridor : MonoBehaviour
{
    public GameObject _BedCorridor;
    public Transform _BedCorridor_Target; // for LookAt
    public GameObject _BedCorridorLight;
    public GameObject TriggerCube;
    public GameObject ThePlayer;
    public Transform _ThePlayer; // for LookAt
    public GameObject PlayerSelfTalkText;
    public AudioSource SoundDuringAnimation, BedApproaches;

    void OnTriggerEnter()
    {
        StartCoroutine(FloatingCorridorBed());

    }

    IEnumerator FloatingCorridorBed()
    {
        SoundDuringAnimation.Play();
        yield return new WaitForSeconds(0.15f);
        _ThePlayer.LookAt(_BedCorridor_Target);

        // ACT STARTS
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        _BedCorridor.GetComponent<MeshRenderer>().enabled = true;
        _BedCorridorLight.GetComponent<Light>().enabled = true;
        _BedCorridor.GetComponent<Animation>().Play("_Corridor_Bed_Animation");
        yield return new WaitForSeconds(1.85f);
    //    SoundDuringAnimation.Stop();
        yield return new WaitForSeconds(0.09f);
      //  BedApproaches.Play();
        //ACT IS ENDING
        yield return new WaitForSeconds(0.17f);
        _BedCorridor.SetActive(false);
        yield return new WaitForSeconds(0.08f);
      //  BedApproaches.Stop();
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TriggerCube.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(PlayerSelfTalk());


    }

    IEnumerator PlayerSelfTalk()
    {
        yield return new WaitForSeconds(2.3f);
        PlayerSelfTalkText.GetComponent<Text>().text = "What have I witnessed?";
        yield return new WaitForSeconds(2.4f);
        PlayerSelfTalkText.SetActive(false);
    }
}
