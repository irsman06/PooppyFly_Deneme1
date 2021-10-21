using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public bool isDead;
    public Rigidbody2D rb2D;
    public float velocity = 1f;
    public GameManager gameManager;
    public GameObject deathScreen;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreArea") {
            gameManager.updateScore();
        }

        if (collision.gameObject.tag == "TimeBonusArea") {
            gameManager.bonusTime();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;
            deathScreen.SetActive(true);
        }
    }
}
