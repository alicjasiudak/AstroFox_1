using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void SetVolume(float Volume)
    {
        Debug.Log(Volume);
        //slider val in log scale
        audioMixer.SetFloat("Volume", Mathf.Log10(Volume)*20);
        PlayerPrefs.SetFloat("vol", Mathf.Log10(Volume)*20);
    }
}
