using UnityEngine;
using System.Collections;

public class SonidosPelota : MonoBehaviour {

    public AudioSource rebote;
    public AudioSource punto;

    /// <summary>
    /// Es un script adicional para el sonido cuando la pelota golpea un bloque [aqui podemos hacer mas cosas de las que están puestas(otro sonido depende que bloque choque....) e incluirlas en el script de pelota y eliminar éste]  
    /// Cuando me de tiempo establecer multiples sonidos [futuro]
    /// </summary>
    /// <param name="otroObjeto"></param>
    void OnCollisionEnter(Collision otroObjeto)
    {
        if (otroObjeto.gameObject.CompareTag("Bloque") || otroObjeto.gameObject.CompareTag("BloquesEspeciales"))
        {
            punto.Play();
        }
        else 
        {
            rebote.Play();
        }
    }
}
