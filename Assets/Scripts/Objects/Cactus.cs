using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    private float takeDamage;
    private float damage;
    public Rigidbody2D RB2D;

    [Header("KnockBack")]

    public bool canMove = true;

    [SerializeField] private Vector2 bounceSpeed;

    [SerializeField] private float lossControlTime;

    void Start()
    {

    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.CompareTag("Player"))
        {
            PlayerScript player = other.collider.GetComponent<PlayerScript>();

            if (player != null)
            {
                //TakeDamage();
            }
  
        }
    }


    public void TakeDamage(float damage, Vector2 position)
    {
        StartCoroutine(lossControl());
        playerBounce(position);
    }


    public void playerBounce(Vector2 hitPoint)
    {
        RB2D.AddForce(hitPoint, ForceMode2D.Impulse);
    }
    private IEnumerator lossControl()
    {
        canMove = false;
        yield return new WaitForSeconds(lossControlTime);
        canMove = true;
    }

}
