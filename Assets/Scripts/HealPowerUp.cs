using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoints = 10;
    public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth) {
                PlayerHealth.instance.HealPlayer(healthPoints);
                AudioManager.instance.PlayClipAt(pickUpSound, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
