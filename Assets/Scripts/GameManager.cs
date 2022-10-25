using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject swipeToRotate;

    public static int currentLevel;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Slider gameProgressSlider;

    public static int noOfPassedRings;

    public static bool mute;

    public static int score = 0;

    public static bool isGameStarted;

    private bool fingerHitGameScreen;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = levelCompleted = mute = false;
        noOfPassedRings = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("helixJumpHighScore", 0);
    }

    void Awake()
    {
        PlayerPrefs.SetInt("helixJumpCurrentLevel", 1); // to remove
        currentLevel = PlayerPrefs.GetInt("helixJumpCurrentLevel", 1);
    }

    void Update()
    {
        //  Set level UI text
        currentLevelText.text = currentLevel.ToString();  
        nextLevelText.text = (currentLevel+1).ToString();

        int progress = noOfPassedRings * (100 / HelixManager.noOfRings);
        gameProgressSlider.value = progress;

        if (gameOver || levelCompleted || mute)
            GameObject.FindGameObjectWithTag("GamePlayAudioManager").GetComponent<AudioSource>().volume = 0;

        if (!mute)
            GameObject.FindGameObjectWithTag("GamePlayAudioManager").GetComponent<AudioSource>().volume = 1;

        //  For PC & Mobile
        fingerHitGameScreen = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0);

        //  Set game started to true if user interacts with the UI when game is not over or level completed
        if (fingerHitGameScreen && !levelCompleted && !gameOver && !isGameStarted)
            isGameStarted = true;

        //  Removes rotation animation instruction when user clicks on screen for the first time
        if (fingerHitGameScreen && !levelCompleted && !gameOver)
            swipeToRotate.SetActive(false);

        if (isGameStarted) {
            highScoreText.text = "";
            scoreText.text = score.ToString();
        }

        if (gameOver) 
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1")) 
            {
                if (score > PlayerPrefs.GetInt("helixJumpHighScore"))
                    PlayerPrefs.SetInt("helixJumpHighScore", score);

                score = 0;
                SceneManager.LoadScene(0);
            }
        }

        if (levelCompleted) 
        {
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1")) 
            {
                PlayerPrefs.SetInt("helixJumpCurrentLevel", currentLevel + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
