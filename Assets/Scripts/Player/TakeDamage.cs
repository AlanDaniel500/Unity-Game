using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Rigidbody2D rb;
     
    PlayerScript player;
    HealthBarScript healthBar;

    [Header("KnockBack")]

    public bool canMove = true;

    [SerializeField] private Vector2 bounceSpeed;

    [SerializeField] private float lossControlTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }
    void Update()
    {
        
    }
    public void getDamage(float damage, Vector2 position)
    {
        player.healthPoints -= damage;
        healthBar.UpdateHealthBar(player.healthPoints, player.maxHealthPoints);
        isDead();
        StartCoroutine(lossControl());
        playerBounce(position);

    }
    private void isDead()
    {
        if (player.healthPoints <= 0)
        {
            Lives.instance.DecreaseLives(1);
            player.healthPoints = 100;

            if (Lives.instance.currentLives <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void playerBounce(Vector2 hitPoint)
    {
        rb.velocity = new Vector2(-(bounceSpeed.x) * hitPoint.x, bounceSpeed.y);
    }
    private IEnumerator lossControl()
    {
        canMove = false;
        yield return new WaitForSeconds(lossControlTime);
        canMove = true;
    }
}
