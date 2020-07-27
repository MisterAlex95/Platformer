using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
