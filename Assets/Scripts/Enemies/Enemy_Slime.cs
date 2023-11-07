using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] public float enemyHealth;
    [SerializeField] private float enemyDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerScript player = other.collider.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.GetDamageWithBounce(enemyDamage, other.GetContact(0).normal);
            }
        }

        StartCoroutine(ReturnToIdleAfterDelay(0.5f));

        if (other.collider.CompareTag("Bullet"))
        {
            takeDamage(Bullet.damage);
        }
    }

    private void takeDamage(float damage)
    {
        enemyHealth -= damage;
        isDead();
        animator.SetBool("Hurt", true);
    }

    private void isDead()
    {
        if (enemyHealth <= 0)
        {
            animator.SetBool("Death", true);
            animator.SetBool("Hurt", false);

            StartCoroutine(DestroyAfterDelay(0.5f));
        }
    }

    private IEnumerator ReturnToIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("Hurt", false);
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}