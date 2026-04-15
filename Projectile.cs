using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision with other objects
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Example: Destroy enemy and the projectile
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}