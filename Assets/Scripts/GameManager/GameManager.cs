using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int PuntosTotales;
    public int puntosSumados;

    private void Awake()
     {
         if (instance == null)
         {
             instance = this;
         }
         else
         {
           Destroy(gameObject);
         }
     }

     public void CambiarEscena(int indice)
     {
         SceneManager.LoadScene(indice);
     }

    public void SumarPuntos(int PuntosASumar)
    {
        puntosSumados += PuntosASumar;
    }


}