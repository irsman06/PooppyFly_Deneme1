using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public int score;
    public Text scoreText;
    public Slider slider;
    public float timeLeft = 1;
    public bool isFlying = false; 

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score"); 
        scoreText.text = score.ToString();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying) {
            timeLeft -= Time.deltaTime / 10;
            if (timeLeft <= 0)
            {
                PlayerPrefs.SetInt("score", score);
                SceneManager.LoadScene("RunScene");
            }
            slider.value = 1 - timeLeft;
        }
    }

    public void updateScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void restartGame() {
        Debug.Log("Restart");
        score = 0;
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene("RunScene");
        score = 0;
        scoreText.text = score.ToString();
    }

    public void bonusTime() {
        timeLeft += 0.2f;
        if (timeLeft>1) {
            timeLeft = 1;
        }
        /*ColorBlock colorblock = slider.colors;
        colorblock.disabledColor = new Color(234, 116, 35, 255f);
        slider.colors = colorblock;*/
    }
}
