using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime = 1.5f;
    private float shootingDirection;
    public static float damage = 25f;

    public void Start()
    {
        Destroy(gameObject, lifetime);
    }
    public void SetDirection(float dir)
    {
        shootingDirection = dir;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.right * shootingDirection * speed * Time.deltaTime);
    }
}
