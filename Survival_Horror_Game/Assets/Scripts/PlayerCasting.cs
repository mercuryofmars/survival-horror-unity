using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCasting : MonoBehaviour
{
    // static is used so later on - other scrips will be able to reference this script.
    public static float DistanceFromTarget; // RayCast - how far away whatever you're looking at is // Won't be seen in inspector
    public float ToTarget; // will be shown in inspector 
    public Transform fpsCam;

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(fpsCam.position, fpsCam.forward, out Hit, Mathf.Infinity)) // position - the positon of what we're doing
                                                                                       // TranformDirection - which way we're facing - which is forward - vector 3 - 3d world.
                                                                                       // out Hit - we're outputting it to the local variable - 'Hit after we fired the RayCast.
        {

            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;


        }
    }
}