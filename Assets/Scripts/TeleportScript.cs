using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] private Transform teleport;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject panel;
    [SerializeField] private float fadeSpeed;
    
    public CanvasGroup uiElement;

    public void FadeIn()
    {
        panel.SetActive(true);
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, 50f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, 50f));
        panel.SetActive(false);

    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }

        print("done");
    }
    
    

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")){
            // FadeIn();
            player.transform.position = teleport.transform.position;
            //FadeOut();
        }

    }
}
