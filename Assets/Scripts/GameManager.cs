using System;
using System.Collections;
using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverText;
        [SerializeField] private GameObject gameWonText;
        [SerializeField] private GameObject timer;
        [SerializeField] private GameObject finish;
        [SerializeField]
        private GameObject player;
        private void OnEnable()
        {
            FallDetection.gameOver += GameOver;
            Timer.gameOver += GameOver;
        }

        private void OnDisable()
        {
            FallDetection.gameOver -= GameOver;
            Timer.gameOver -= GameOver;
        }

        void GameOver()
        {
            gameOverText.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Animator>().enabled = false;
                timer.SetActive(false);
                gameWonText.SetActive(true);

            }
        }
    }