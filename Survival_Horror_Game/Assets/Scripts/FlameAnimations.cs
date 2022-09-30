using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    public int LightMode;
    public GameObject FlameLight;

    void Update()
    {
        if (LightMode == 0) // by default Unity starts at 0.
        {
            StartCoroutine(AnimateLight()); // starting the routine anytime we want.
        }
    }


    IEnumerator AnimateLight() // in order to delay the script from running. This cannot be done from 'void'.
    {
        LightMode = Random.Range(1, 4); // the reason it's 4 is due to a quark with random range - it never picks the max number which is 4.
        if (LightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim1");
        }
         if (LightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim2");

        }
        if (LightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim3");

        }

        yield return new WaitForSeconds(0.99f); // allowing the script to wait for just under 1 second so the animation will complete. 
        LightMode = 0;
    }
}
