using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class GameController : MonoBehaviour
{
    public float startTime = 30f;
    private float timeRemaining;
    public Text timerText;
    public Text scoreText;
    public GameObject[] objectsToSpawn;
    public float spawnInterval = 2f;
    private int score = 0;

    public Color[] groundColors;
    public Transform[] groundTransforms;

    void Start()
    {
        timeRemaining = startTime;
        UpdateTimerText();
        UpdateScoreText();

        for (int i = 0; i < groundTransforms.Length; i++)
        {
            SpriteRenderer groundRenderer = groundTransforms[i].GetComponent<SpriteRenderer>();
            if (groundRenderer != null)
            {
                groundColors[i] = groundRenderer.color;
            }
        }
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            EndGame();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Round(timeRemaining);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
    public void RemoveScore(int points)
    {
        score -= points;
        UpdateScoreText();
    }

    void EndGame()
    {
        timerText.text = "Time's up!";
        Time.timeScale = 0; 
    }
    public bool IsGameActive()
    {
        return timeRemaining > 0;
    }
    public int GetGroundIndex(Vector3 position)
    {
        for(int i=0;i<groundTransforms.Length; i++)
        {
            if (position.x >= groundTransforms[i].position.x - 2f && position.x < groundTransforms[i].position.x + 2f)
            {
                return i;
            }
        }
        return -1;
    }
    public Color GetGroundColor(Vector3 position)
    {
        int groundIndex = GetGroundIndex(position);
        if(groundIndex != -1)
        {
            return groundColors[groundIndex];
        }
        return Color.clear;
    }
}