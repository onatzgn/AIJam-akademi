using oyun3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cathers : MonoBehaviour
{
    public GameManager GameManager;
    public int skor=10;
    List<GameObject> currentObjects=new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentObjects.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentObjects.Remove(collision.gameObject);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentObjects.Count > 0)
            {
                for(int i = 0; i < currentObjects.Count; i++)
                {
                    GameManager.UpdateScoreText(skor);
                    Destroy(currentObjects[i]);

                }
                currentObjects.Clear();
            }
        }
    }

}
