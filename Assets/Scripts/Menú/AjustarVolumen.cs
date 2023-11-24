using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AjustarVolumen : MonoBehaviour
{
    [SerializeField] private Slider barraVolumen = null;


    void Start()
    {
       //Si el jugador no tiene una configuracion guardada, se pone en 1
        if (PlayerPrefs.HasKey("volumen"))
        {
            PlayerPrefs.SetFloat("volumen", 1);
            Cargar();
        }
        else
        {
            Cargar();
        }
    }

    public void CambiarVolumen ()
    {
       AudioListener.volume = barraVolumen.value;
        Guardar();
    }

    private void Cargar()
    {
        barraVolumen.value = PlayerPrefs.GetFloat("volumen");
    }

    private void Guardar()
    {
        PlayerPrefs.SetFloat("volumen",barraVolumen.value);
    }
    

}
