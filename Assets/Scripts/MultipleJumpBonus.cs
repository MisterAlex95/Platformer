using UnityEngine;

public class MultipleJumpBonus : MonoBehaviour
{
    public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Inventory.instance.AddJump(1);
            AudioManager.instance.PlayClipAt(pickUpSound, transform.position);
            Destroy(gameObject);
        }
    }
}
