using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class PlayerGlobalHealth : MonoBehaviour
{
    public static int currentHealth = 20; // static doesn't appear in inspector
    public int internalHealth; // this does appear
    public GameObject ThePlayer;
    public GameObject PlayerCamera;
    public GameObject TheGun;
    public AudioSource PlayerHitsGround, PlayerDiesTinnitus;
    int counter = 0;
    void Update()
    {
        internalHealth = currentHealth;
        if (currentHealth <= 0 & counter == 0)
        {
            counter++;
            StartCoroutine(PlayerDeathScene());
        }

    }

    IEnumerator PlayerDeathScene()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        TheGun.SetActive(false);
        PlayerCamera.GetComponent<Animation>().Play("PlayerDiedAnim");
        yield return new WaitForSeconds(1.6f);
        PlayerHitsGround.Play();
        yield return new WaitForSeconds(0.2f);
        PlayerDiesTinnitus.Play();
        yield return new WaitForSeconds(4.1f);
        SceneManager.LoadScene(1); // Game over scene

    }

}
