using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oyun3
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] fallingObjects;
        public Transform[] spawnPoints;
        public Text scoreText;
        public Text timerText;
        public Image[] colorZones;
        public Color[] colors;

        private int score = 0;
        private float timer = 30f;
        private bool isGameActive = true;

        void Start()
        {
     
            UpdateTimerText();
        }

        void Update()
        {
            if (!isGameActive)
                return;

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isGameActive = false;
                timer = 0;
            }
            UpdateTimerText();
        }

        public void UpdateScoreText(int _skor)
        {
            score += _skor;
            scoreText.text = "Score: " + score;
        }

        void UpdateTimerText()
        {
            timerText.text = "Time: " + Mathf.Round(timer);
        }
    }
}