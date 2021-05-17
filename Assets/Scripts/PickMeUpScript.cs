using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUpScript : MonoBehaviour
{
    private AudioSource source;
    [SerializeField]
    private AudioClip sound;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(sound);
        }
    }
}
