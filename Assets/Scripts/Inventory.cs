using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    
    public static Inventory instance;
    public Text coinsCountText;

    private void Awake() {
        if (instance) {
            Debug.LogWarning("There is more than one instance of inventory !");
            return;
        }
        instance = this;
    }

    public void AddCoins(int _count) {
        coinsCount += _count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int _count) {
        coinsCount -= _count;
        coinsCountText.text = coinsCount.ToString();
    }

}
