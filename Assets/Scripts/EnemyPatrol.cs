using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer spriteRenderer;
    public int damageOnCollision = 20;

    private Transform target;
    private int destPoint;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Flip(dir.x);

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        // enemy near his destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f) {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }

    void Flip(float _direction) {
        if (_direction > 0.1f) {
            spriteRenderer.flipX = false;
        } else if (_direction < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
