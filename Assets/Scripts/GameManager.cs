using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace oyun3
{
    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI timerText;

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
                PlayerPrefs.SetInt("game2",1);
                PlayerPrefs.SetInt("game2_score",score);
                SceneManager.LoadScene("StartScene");
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