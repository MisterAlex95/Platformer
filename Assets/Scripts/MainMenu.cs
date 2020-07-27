﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;

    public void StartGame() {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Settings() {
        settingsWindow.SetActive(true);
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void CloseSettingsMenu() {
        settingsWindow.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }
}
