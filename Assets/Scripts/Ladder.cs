using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour {
    public BoxCollider2D platformCollider;

    private bool isInRange = false;
    private Movement playerMovement;
    private Text interactUI;

    void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update() {
        if (isInRange) {
            if (playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E)) {
                playerMovement.isClimbing = false;
                platformCollider.isTrigger = false;
                return;
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                playerMovement.isClimbing = true;
                platformCollider.isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isInRange = false;
            interactUI.enabled = false;
            playerMovement.isClimbing = false;
            platformCollider.isTrigger = false;
        }
    }
}
