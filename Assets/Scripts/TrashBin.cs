using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public int scoreLimit = 5; 
    private int score = 0;
    private float timeElapsed = 0f;
    private bool gameEnded = false;

    void Update()
    {
        if (!gameEnded)
        {
            timeElapsed += Time.deltaTime;

            if (score >= scoreLimit)
            {
                gameEnded = true;
                Debug.Log("Tüm virüsler " + timeElapsed + " saniyede temizlendi");
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

