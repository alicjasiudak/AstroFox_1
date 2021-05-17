using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private readonly int fall = Animator.StringToHash("Fall");
    public delegate void GameOver();
    public static event GameOver gameOver;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Fox");
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -2)
        {
            anim.SetTrigger(fall);
            gameOver();
        }
    }
}
