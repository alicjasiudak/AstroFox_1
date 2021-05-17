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
    private bool stepedon =  false;
    
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
  /*  IEnumerator FadeInOut()
    {
        Debug.Log("canvas inactive");
        canvas.SetActive(true);
        Debug.Log("canvas activated");

        var material = canvas.GetComponent<Image>().material;
        //forever
        while (true)
        {
            // fade in
            yield return Fade(material, 1);
            // wait
            Debug.Log("should have faded in");

            yield return new WaitForSeconds(1);
            // fade out
            yield return Fade(material, 0);
            Debug.Log("and should have faded out");

            // wait
            canvas.SetActive(false);
            stepedon = false;
        }
    }

    IEnumerator Fade(Material mat, float targetAlpha)
    {
        while (mat.color.a != targetAlpha)
        {
            var newAlpha = Mathf.MoveTowards(mat.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, newAlpha);
            yield return null;
        }
    }*/
}
