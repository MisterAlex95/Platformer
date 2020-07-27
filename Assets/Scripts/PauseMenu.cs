using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsWindow;
    public static bool gameIsPaused = false;
    public static PauseMenu instance;

    private void Awake() {
        if (instance) {
            Debug.LogWarning("There is more than one instance of PauseMenu !");
            return;
        }
        instance = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resumed();
            } else {
                Paused();
            }
        }
    }

    public void Paused() {
        Movement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resumed() {
        Movement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void OpenSettingsWindow() {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsMenu() {
        settingsWindow.SetActive(false);
    }
    
    public void MainMenuButton() {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resumed();
        SceneManager.LoadScene("MainMenu");
    }
}
