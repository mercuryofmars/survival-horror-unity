using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GroundBehaviour : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public FirstPersonController FPC;
    public string currentGround;

     void Start()
    {
        setGroundType(GroundTypes[0]);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Sand")
        {
            setGroundType(GroundTypes[1]);
        }
        else
        {
            setGroundType(GroundTypes[0]);
        }
    }

    public void setGroundType(GroundType ground)
    {
        if (currentGround != ground.name)
        {
            FPC.m_FootstepSounds = ground.footstepsounds;
            FPC.m_WalkSpeed = ground.walkspeed;
            FPC.m_RunSpeed = ground.runSpeed;
            currentGround = ground.name;
        }
    }
}

[System.Serializable]
public class GroundType
{
    public string name;
    public AudioClip[] footstepsounds;
    public float walkspeed = 1.7f;
    public float runSpeed = 2.1f;
}

