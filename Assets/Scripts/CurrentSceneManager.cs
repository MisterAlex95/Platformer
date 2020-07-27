using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerIsPresentByDefault = false;
    public int coinsPickedUpInThisSceneCount;

    public static CurrentSceneManager instance;

    void Awake() {
        if (instance) {
            Debug.LogWarning("There is more than one instance of CurrentSceneManager !");
            return;
        }
        instance = this;
    }
}
