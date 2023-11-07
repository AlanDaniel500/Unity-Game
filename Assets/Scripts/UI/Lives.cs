using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public TMP_Text livesText;
    public int currentLives = 0;

    public static Lives instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateLivesText();
    }

    public void IncreaseLives(int Lives)
    {
        currentLives += Lives;
        UpdateLivesText();
    }
    public void DecreaseLives(int Lives)
    {
        currentLives -= Lives;
        UpdateLivesText();
    }
    void UpdateLivesText()
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }
}