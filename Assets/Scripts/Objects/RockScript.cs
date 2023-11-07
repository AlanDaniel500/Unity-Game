using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float RockHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            TakeDamage(Bullet.damage);
        }
    }
    public void TakeDamage(float damage)
    {
        RockHealth -= damage;
        isBroken();
    }
    private void isBroken()
    {
        if (RockHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}