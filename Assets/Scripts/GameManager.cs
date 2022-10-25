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

    public static int currentLevel;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public Slider gameProgressSlider;

    public static int noOfPassedRings;

    public static bool mute;    

    void Start()
    {
        Time.timeScale = 1;
        gameOver = levelCompleted = mute = false;
        noOfPassedRings = 0;
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

        if (gameOver) 
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
                SceneManager.LoadScene(0);
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
