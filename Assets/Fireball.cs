using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float velocityX = 5f;
    public Rigidbody2D rb;

    private float velocityY = 0f;

    void Update()
    {
        rb.velocity = new Vector2(velocityX, velocityY);
        Destroy(gameObject, 3f);
    }
}
