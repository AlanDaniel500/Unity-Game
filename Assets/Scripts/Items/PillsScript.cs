using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsScript : MonoBehaviour
{
    private int value = 1;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Pills"), LayerMask.NameToLayer("Enemy"), true);
    }

    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Lives.instance.currentLives < 3)
            {
                Destroy(gameObject);
                Lives.instance.IncreaseLives(value);
            }
        }
    }
}
