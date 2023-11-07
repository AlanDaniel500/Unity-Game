using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    PlayerScript player;

    private float healRate = 10.0f;

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player = collider.GetComponent<PlayerScript>();
            Healing(player);
        }
    }
    private void Healing(PlayerScript player)
    {
        if (player.healthPoints < player.maxHealthPoints)
        {
            float healAmount = healRate * Time.deltaTime;
            player.healthPoints += healAmount;

            if (player.healthPoints > player.maxHealthPoints)
            {
                player.healthPoints = player.maxHealthPoints;
            }
        }
    }
}
