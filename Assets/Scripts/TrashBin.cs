using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public int scoreLimit = 5; 
    private int score = 0;
    private float timeElapsed = 0f;
    private bool gameEnded = false;
    public GameObject kazandinText;

    void Update()
    {
        if (!gameEnded)
        {
            timeElapsed += Time.deltaTime;

            if (score >= scoreLimit)
            {
                gameEnded = true;
                kazandinText.SetActive(true);
                PlayerPrefs.SetInt("game1", 1);
                PlayerPrefs.SetInt("game1_score", score);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameEnded && other.CompareTag("Trash"))
        {
            score++;
            Destroy(other.gameObject);
            Debug.Log("Score: " + score);
        }
    }
}

