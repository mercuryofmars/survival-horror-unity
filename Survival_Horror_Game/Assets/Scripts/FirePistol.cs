using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// IS ATTACHED TO THE REAL GUN GAME OBJECT IN ORDER TO ACTIVATE ONLY WHEN PLAYER HAS THE GUN - ACTIVE
public class FirePistol : MonoBehaviour
{
    public GameObject ThePistol;
    public GameObject PistolMuzzle;
    public GameObject lastHit;
    public AudioSource PistolFires, PistolWithoutAmmoSound;
    public GameObject ActionText;
    public GameObject TheZombie;
    public Transform fpsCam;
    public static bool IsFiring = false;
    public static bool IsZombieBeingShot = false;
    public static int CounterZombieHits;
    public float TargetDistance;
    float RayCastRange = 50f;
    int counter = 0;
    int DamageAmount = 5;

    

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ZombieDeath.StatusCheck != 2)
        {
            if (IsFiring == false && OpenAmmoDrawer.playerPickedAmmo == true && OpenAmmoDrawer.currentAmmo > 0)
            {
                OpenAmmoDrawer.currentAmmo -= 1;
                StartCoroutine(FiringPistol());
            }
            if (OpenAmmoDrawer.currentAmmo <= 0 || OpenAmmoDrawer.playerPickedAmmo == false)
            {
                counter++;
                StartCoroutine(PistolWithoutAmmo());
            }
        }

    }


    void FixedUpdate()
    {
       // transform.position = Input.mousePosition;
      //  RaycastHit Shot;
      //  if (IsFiring == true)
       //  {
         //   if (Physics.Raycast(transform.position, transform.forward, out Shot, 10000f))
         //   {
            //    Debug.DrawRay(transform.position, transform.forward, Color.green);
             //   lastHit = Shot.transform.gameObject;
                //  Debug.Log(Shot.transform.gameObject);
                //    TargetDistance = Shot.distance;
                //   ZombieWasHit = true;
                //  Shot.transform.SendMessage("ZombieLosesHealth", SendMessageOptions.DontRequireReceiver);
                // TheZombie.GetComponent<ZombieDeath>().SendMessage("ZombieLosesHealth", SendMessageOptions.DontRequireReceiver);
                //   TargetDistance = Shot.distance;            
                //  Shot.transform.SendMessage("ZombieLosesHealth", SendMessageOptions.DontRequireReceiver); // sending value to DamageZombie method within ZombieDeath script, not asking anything back. 
           // }
      //  }
    }

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;

        if (ZombieDeath.StatusCheck != 2)
        {
            IsFiring = true;

            if (Physics.Raycast(fpsCam.position, fpsCam.forward, out Shot, RayCastRange) && Shot.transform.tag == "Enemy")
            {
                TheZombie.GetComponent<ZombieDeath>().SendMessage("ZombieLosesHealth", DamageAmount, SendMessageOptions.DontRequireReceiver);
              
            }

            ThePistol.GetComponent<Animation>().Play("PistolFiresAnimation");
            PistolMuzzle.SetActive(true);
            PistolFires.Play();
            yield return new WaitForSeconds(0.09f);
            PistolMuzzle.SetActive(false);
            yield return new WaitForSeconds(0.9f);
            IsFiring = false;
        }
    }


    IEnumerator PistolWithoutAmmo()
    {
        if (counter == 1 && ZombieDeath.StatusCheck !=2)
        {
            PistolWithoutAmmoSound.Play();
            ActionText.GetComponent<Text>().text = "I need to find ammo";
            ActionText.SetActive(true); // showing the text - explanation
            yield return new WaitForSeconds(1f);
            ActionText.SetActive(false); // unshowing the text - explanation
        }
        else // in order to prevent two sounds one after the other
        {
            PistolWithoutAmmoSound.Play();
            yield return new WaitForSeconds(0.2f);
        }
    }


}
