using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetObstacle : HuyMonoBehaviour
{
    [SerializeField] protected GameManager gameManager;

    protected virtual void LoadGameManager()
    {
        if (gameManager != null) return;
        gameManager = transform.Find("GameManager").GetComponent<GameManager>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.transform.gameObject.CompareTag("Obstacle"))
            {
                Time.timeScale = 0f;
                Debug.Log("GameOver");
                this.gameManager.gameoverBackground.gameObject.SetActive(true);
            }
        }
    }
}
