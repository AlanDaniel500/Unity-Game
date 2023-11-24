using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salirCueva : MonoBehaviour
{
    public int indice; // El índice de la escena a la que deseas cambiar

    private GameManager gameManager;

    private void Start()
    {
        // Encuentra el GameManager en la escena
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Update();
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameManager.CambiarEscena(indice);
        }
    }

}
