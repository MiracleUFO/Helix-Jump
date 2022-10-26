using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI muteText;
    private bool menuShow;
    public GameObject[] menuIcons;
    
    void Start()
    {
        menuShow = true;
    }

    public void ToggleMute()
    {
        if (GameManager.mute) {
            GameManager.mute = false;
            muteText.text = "";
        } else {
            GameManager.mute = true;
            muteText.text = "/";
        }
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Game Quitted");
    }

    public void ToggleMenuShow()
    {
        menuShow = !menuShow;

        for (int i = 0; i < menuIcons.Length; i++) {
            menuIcons[i].SetActive(menuShow);
            menuIcons[menuIcons.Length - 1].SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ToggleStore(GameObject Menu)
    {
        if (Menu.activeSelf) {
            Time.timeScale = 1;
            Menu.SetActive(false);
        } else {
            Time.timeScale = 0;
            Menu.SetActive(true);
        }
       
    }
}
