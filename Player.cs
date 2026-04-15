using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    void Update() {
        HandleMovement();
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void HandleMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void Shoot() {
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f));
    }
}