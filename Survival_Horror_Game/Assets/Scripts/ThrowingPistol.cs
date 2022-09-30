using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingPistol : MonoBehaviour
{
    public GameObject ThePistol, PlayerCamera;
    public Rigidbody ThePistolRB;
    public AudioSource PistolHitsTheGround;
    int counter = 0;
    // Update is called once per frame
    void Update()
    {
        if (ZombieDeath.StatusCheck == 2 && counter == 0)
        {
            counter++;
            StartCoroutine(PistolThrownAway());
        }
    }

    IEnumerator PistolThrownAway()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerCamera.GetComponent<Animation>().Play("PlayerKillsZombieInShock");
        yield return new WaitForSeconds(1.5f);
        ThePistol.transform.parent = null;
        ThePistolRB.isKinematic = false;
        ThePistolRB.useGravity = enabled;
        yield return new WaitForSeconds(0.2f);
        PistolHitsTheGround.Play();

    }
}
