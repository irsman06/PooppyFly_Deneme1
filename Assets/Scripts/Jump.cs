using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public bool isDead;
    public Rigidbody2D rb2D;
    public float velocity = 1f;
    public GameManager gameManager;
    public GameObject deathScreen;
    public Animator jumpAnimator;
    public AudioSource audioSource;

    private void Start()
    {
        Time.timeScale = 1;
        jumpAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (rb2D.velocity.y < 0.01 && -0.01 < rb2D.velocity.y)
            {
                rb2D.velocity = Vector2.up * velocity;
                jumpAnimator.ResetTrigger("OnTheRoadAgain");
                jumpAnimator.SetTrigger("InTheAir");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreArea")
        {
            gameManager.updateScore();
        }
        else if (collision.gameObject.tag == "FlyCandy")
        {
            Debug.Log("Flyyy");
            PlayerPrefs.SetInt("score", gameManager.score);
            SceneManager.LoadScene("FlyScene");
        }
    }
    //PlayerPrefs.Save();
    //erdemDeneme1
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            gameManager.score = 0;
            PlayerPrefs.SetInt("score", 0);
            audioSource.Play();
            isDead = true;
            Time.timeScale = 0;
            deathScreen.SetActive(true);
            gameManager.audioSource.Pause();
        }
        else if(collision.gameObject.name =="Platform")
        {
            jumpAnimator.ResetTrigger("InTheAir");
            jumpAnimator.SetTrigger("OnTheRoadAgain");
        } 
    }
}
