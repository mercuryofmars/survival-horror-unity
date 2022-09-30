using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdRoomSequence : MonoBehaviour
{
     public static bool isGroundChanged = false;

    void Update()
    {

    }

    void OnTriggerEnter()
    {
        isGroundChanged = true;
        Debug.Log(isGroundChanged);
    }


}
