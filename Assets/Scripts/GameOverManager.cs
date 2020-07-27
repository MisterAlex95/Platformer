using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;

    private void Awake() {
        if (instance) {
            Debug.LogWarning("There is more than one instance of GameOverManager !");
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath() {
        gameOverUI.SetActive(true);
        if (CurrentSceneManager.instance.isPlayerIsPresentByDefault) {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
    }

    public void RetryButton() {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        PlayerHealth.instance.Respawn();
    }

    public void MainMenuButton() {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton() {
        Application.Quit();
    }
}
