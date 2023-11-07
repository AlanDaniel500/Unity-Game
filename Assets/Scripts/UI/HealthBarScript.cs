using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image HealthBar;

    public void UpdateHealthBar(float healthPoints, float maxHealthPoints)
    {
        HealthBar.fillAmount = healthPoints / maxHealthPoints;
    }
}