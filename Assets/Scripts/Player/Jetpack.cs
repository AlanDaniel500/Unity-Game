using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    Rigidbody2D rb;
    public float JetpackFoce;
    PlayerScript player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerScript>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.LeftShift) && player.inFloor==false)
            rb.AddForce((transform.up - transform.right) * JetpackFoce, ForceMode2D.Force);

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && player.inFloor == false)
            rb.AddForce((transform.up + transform.right) * JetpackFoce, ForceMode2D.Force);

        else if (Input.GetKey(KeyCode.LeftShift))
            rb.AddForce((transform.up) * JetpackFoce, ForceMode2D.Force);
    }
}
