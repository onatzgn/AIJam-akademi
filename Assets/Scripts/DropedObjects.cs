using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float speed = 2f;
    private SpriteRenderer spriteRenderer;
    private GameController gameController;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>();
        spriteRenderer.color = gameController.GetGroundColor(transform.position);

    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Color groundColor = collision.GetComponent<SpriteRenderer>().color;

            if (groundColor == spriteRenderer.color)
            {
                gameController.AddScore(1);
            }

            else
            {
                gameController.RemoveScore(1);
            }

            Destroy(gameObject);
        }
    }
}
