using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorMoneda : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;
    void Update()
    {
        puntos.text = GameManager.instance.PuntosTotales.ToString();
    }
}
