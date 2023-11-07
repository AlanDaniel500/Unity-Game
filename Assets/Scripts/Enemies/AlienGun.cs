using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class AlienGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }

    }

    void shoot() 
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }



}
   


