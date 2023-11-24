using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private Image barraImagen;

    public void ActualizarBarraDeVida(float maxVida, float vida)
    {
        barraImagen.fillAmount = vida / maxVida;
    }
}
