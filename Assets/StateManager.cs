using Aeterponis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public ChatWindow chatWindow;

    public GameObject gemini0;
    public GameObject gemini1;
    public GameObject gemini2;
    public GameObject geminiFinal;

    public GameObject[] pps;

    int game1 = 0;
    int game1_score = 0;
    int game2 = 0;
    int game2_score = 0;
    int game3 = 0;
    int game3_score = 0;



    public void InitState()
    {
        LoadGameData("game1", ref game1, ref game1_score);
        LoadGameData("game2", ref game2, ref game2_score);
        LoadGameData("game3", ref game3, ref game3_score);

        SetGeminiActiveState();
    }

    private void LoadGameData(string key, ref int game, ref int gameScore)
    {
        if (PlayerPrefs.HasKey(key))
        {
            game = PlayerPrefs.GetInt(key, 0);
            gameScore = PlayerPrefs.GetInt($"{key}_score", 0);
        }
    }

    private void SetGeminiActiveState()
    {
        if (game1 == 0)
        {
            gemini0.SetActive(true);
            chatWindow.currentAI = gemini0.GetComponent<AITest>();
            OSManager.instance.state = GameStates.start;
        }
        else if (game1 == 1 && game2 == 0)
        {
            gemini1.SetActive(true);
            chatWindow.currentAI = gemini1.GetComponent<AITest>();
            pps[0].SetActive(true);

            OSManager.instance.state = GameStates.after1;

        }
        else if (game1 == 1 && game2 == 1 && game3 == 0)
        {
            gemini2.SetActive(true);
            chatWindow.currentAI = gemini2.GetComponent<AITest>();
            pps[0].SetActive(true);
            pps[1].SetActive(true);


            OSManager.instance.state = GameStates.after2;

        }
        else if (game1 == 1 && game2 == 1 && game3 == 1)
        {
            geminiFinal.SetActive(true);
            chatWindow.currentAI = geminiFinal.GetComponent<AITest>();
            pps[0].SetActive(true);

            pps[1].SetActive(true);

            pps[2].SetActive(true);

            OSManager.instance.state = GameStates.final;

        }
    }

}

public enum GameStates
{
    start,
    after1,
    after2,
    final
}
