using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDeath : MonoBehaviour
{
    public static bool ZombieHealthStatus = true;
    public int ZombieHealth = 20;
    public GameObject TheZombie;
    public GameObject TorchZombie_Loom, TorchZombie_Particles;
    public NavMeshAgent _TheZombie;
    public AudioSource clip;
    public Rigidbody Zombie_RB;
    public static int StatusCheck = 0;  // not bool because might be more than 2 status
 

    void ZombieLosesHealth(int DamageAmount)
    {
        ZombieHealth -= DamageAmount;

    }
    // Update is called once per frame
    void Update()
    {
        if (ZombieHealth <= 0 && StatusCheck == 0)
        {
            StatusCheck = 2; // in order to not run this if statement again - once.
            TheZombie.GetComponent<Animation>().Stop("Z_Walk1_InPlace");
            TheZombie.GetComponent<Animation>().Play("Z_FallingBack");
            TheZombie.GetComponent<BoxCollider>().enabled = false;
            ZombieHealthStatus = false;
           // Zombie_RB.constraints = RigidbodyConstraints.FreezePosition;
            _TheZombie.SetDestination(TheZombie.transform.position);
            clip.Play();
            TorchZombie_Loom.SetActive(true);
            TorchZombie_Particles.SetActive(true);
        }
    }


}
