using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] private GameObject efectoExplosion;
    [SerializeField] private float tiempoParaDestruir = 1f; // Agrega este campo
    private AudioSource Explosion;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            explosion();
            animacion();
            StartCoroutine(DestruirBomba()); // Iniciar la rutina de destrucción
            Explosion.Play();
        }
    }

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Explosion = GetComponent<AudioSource>();
    }

    private void animacion()
    {
        anim.SetBool("EspacioApretado", true);
        anim.SetBool("explosion", false);
    }

    public void explosion()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in objetos)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerzaFinal);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    // Rutina para destruir la bomba después de un tiempo
    private IEnumerator DestruirBomba()
    {
        yield return new WaitForSeconds(tiempoParaDestruir);
        Destroy(gameObject);
    }
}





