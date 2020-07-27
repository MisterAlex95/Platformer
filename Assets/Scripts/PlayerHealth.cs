using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invinsibilityTimeAfterHit = 3f;
    public float invinsibilityFlashDelay = .2f;
    public bool isInvinsible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public AudioClip hitSound;

    public static PlayerHealth instance;

    private void Awake() {
        if (instance) {
            Debug.LogWarning("There is more than one instance of PlayerHealth !");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            TakeDamage(50);
        }
    }

    public void HealPlayer(int _heal) {
        currentHealth = Mathf.Max(currentHealth + _heal, maxHealth);
        healthBar.setHealth(currentHealth);
    }

    public void TakeDamage(int _damage) {
        if (!isInvinsible) {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= _damage;
            healthBar.setHealth(currentHealth);

            if (currentHealth <= 0) {
                Die();
                return;
            }

            isInvinsible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die() {
        Movement.instance.enabled = false;
        Movement.instance.animator.SetTrigger("Death");
        Movement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        Movement.instance.rb.velocity = Vector3.zero;
        Movement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn() {
        Movement.instance.enabled = true;
        Movement.instance.animator.SetTrigger("Respawn");
        Movement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        Movement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);
    }

    public IEnumerator InvincibilityFlash() {
        while (isInvinsible) {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invinsibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invinsibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay() {
        yield return new WaitForSeconds(invinsibilityTimeAfterHit);
        isInvinsible = false;
    }
}
