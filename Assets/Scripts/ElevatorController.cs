using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public GameObject movePlatform;
    
    private void OnTriggerStay(Collider coll)
    {
        if(coll.CompareTag("Player"))
            movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
        //StartCoroutine(Fade());

    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.magenta, Color.white, f);
            yield return null;
        }
    }
    
    IEnumerator SendElevatorDown()
    {
        //Stop the platform from moving here.
        //wait for the desired amount of seconds (float);
        yield return new WaitForSeconds(1.0f);
        movePlatform.transform.position += movePlatform.transform.forward * Time.deltaTime;
 
    }
}
