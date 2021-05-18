using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public GameObject movePlatform;

    private void OnTriggerStay(Collider coll)
    {
        if(coll.CompareTag("Player")){
            movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.001f)
        {
            Color c = movePlatform.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, Color.magenta, f);
            yield return null;
        }
    }
}
