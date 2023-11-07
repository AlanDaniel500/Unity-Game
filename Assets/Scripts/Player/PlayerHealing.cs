using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealing : MonoBehaviour
{
    public static void Heal(PlayerScript player)
    {
        if (player != null)
        {
            if ((player.healthPoints + player.healingPoints) > player.maxHealthPoints)
            {
                player.healthPoints = player.maxHealthPoints;
                player.healingPoints -= (player.maxHealthPoints - player.healthPoints);
                Debug.Log("CURADO");
            }
            else
            {
                player.healthPoints += player.healingPoints;
                player.healingPoints = 0;
                Debug.Log("CURADO");
            }
        }
    }
}
