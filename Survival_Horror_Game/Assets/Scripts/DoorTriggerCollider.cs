using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerCollider : MonoBehaviour
{
    public GameObject DoorTrigger;
    public GameObject TheZombie;
    void Update()
    {
        if (ZombieDeath.StatusCheck == 2)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }


}
