using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Simple AI movement (moves towards player)
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject); // Destroy the bullet
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle enemy death (e.g., play animation, drop loot)
        Destroy(gameObject);
    }
}