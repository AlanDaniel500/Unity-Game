using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private float health = 1000f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float rotationSpeed = 100f;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerScript player = other.collider.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.GetDamageWithBounce(damage, other.GetContact(0).normal);
            }
        }
        else if (other.collider.CompareTag("Bullet"))
            health -= damage;
    }
    void FixedUpdate()
    {
        ConstantRotation();

        if (health <= 0)
            Destroy(gameObject);
    }
    void ConstantRotation()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}