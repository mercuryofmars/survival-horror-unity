using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject ThePlayerCamera;
    public GameObject TheZombie;
    public GameObject ZombieTargetsNewDestination;
    public NavMeshAgent zombie;
    public Rigidbody ZombieRB;
    public SkinnedMeshRenderer[] smr = new SkinnedMeshRenderer[14];
    public float ZombieSpeed = 0.01f;
    public bool attackTrigger = false;
    public bool isZombieAttacking = false;
    public bool waitForRound = false;   // for zombie appear and dissapear
    public AudioSource[] PlayerIsHitByZombie = new AudioSource[4];
    bool isPlaying = false;
    int random = 0;
    void Update()
    {

        //ZombieRB.AddForce(Vector3.up * -10);

        if (ZombieDeath.StatusCheck != 2)
        {
            //  transform.LookAt(ThePlayer.transform);
            if (attackTrigger == false)
            {
                //  ZombieSpeed = 0.01f;
                TheZombie.GetComponent<Animation>().Play("Z_Walk1_InPlace");
                //   transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, ZombieSpeed); //Zombie's heading towards Player
                //                transform.position = Vector3.MoveTowards(transform.position, new Vector3(ThePlayer.transform.position.x, 0, ThePlayer.transform.position.z), ZombieSpeed);
                zombie.SetDestination(ThePlayer.transform.position); // used from unityengine.ai
                if (waitForRound == false)
                {
                    StartCoroutine(ZombieAppearsAndDisappears());

                }
            }

            if (PlayerGlobalHealth.currentHealth <= 0 )
            {
                TheZombie.GetComponent<Animation>().Play("Z_Walk1_InPlace");
                zombie.SetDestination(ZombieTargetsNewDestination.transform.position); // used from unityengine.ai

            }
            if (attackTrigger == true && isZombieAttacking == false && PlayerGlobalHealth.currentHealth > 0) // if Zombie is in attacking range and not attacking yet - do something
            {
                ZombieSpeed = 0;
                TheZombie.GetComponent<Animation>().Play("Z_Attack");
                ThePlayerCamera.GetComponent<Animation>().Play("PlayerIsHitAnim");
                StartCoroutine(ZombieCausesDamage());
                StartCoroutine(PlayPlayerHitSounds());
            }
        }
    }

    IEnumerator ZombieCausesDamage()
    {
        isZombieAttacking = true;
        yield return new WaitForSeconds(1.5f); // waiting for attacking animation to play
        PlayerGlobalHealth.currentHealth -= 5;
        yield return new WaitForSeconds(1f);
        isZombieAttacking = false;


    }

    IEnumerator ZombieAppearsAndDisappears()
    {
        waitForRound = true;
        yield return new WaitForSeconds(3.5f);
        if (ZombieDeath.StatusCheck != 2)
        {
            for (int i = 0; i <= 13; i++)
            {
                smr[i].enabled = false;
            }
        }

        if (ZombieDeath.StatusCheck != 2)
        {
            yield return new WaitForSeconds(3.5f);
            for (int i = 0; i <= 13; i++)
            {
                smr[i].enabled = true;
            }
            waitForRound = false;
        }
    }

    IEnumerator PlayPlayerHitSounds()
    {
        isPlaying = true;
        random = Random.Range(1, 4);
        PlayerIsHitByZombie[random].Play();
        yield return new WaitForSeconds(1f);
        PlayerIsHitByZombie[random].Stop();
        isPlaying = false;

    }

    void OnTriggerEnter()
    {
        attackTrigger = true;
    }

    void OnTriggerExit()
    {
        attackTrigger = false;
    }
}
