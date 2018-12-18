using UnityEngine;
using System.Collections;

public class SonidosFinPartida : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip completado;
    public AudioClip gameOver;
    public AudioSource audioSourceSuelo;

    public void GameOver()
    {
        ReproduceSonido(gameOver);
    }

    public void NivelCompletado()
    {
        ReproduceSonido(completado);
    }

    public void SonidoSuelo()
    {
        audioSourceSuelo.enabled = true;
        audioSourceSuelo.Play();
    }

    /// <summary>
    /// Función genérica que reproduce el sonido que tu quieres pasandole por parametro un Audio 
    /// </summary>
    /// <param name="sonido"></param>
    private void ReproduceSonido(AudioClip sonido)
    {
        audioSource.clip = sonido;
        audioSource.loop = false;
        audioSource.Play();
    }

}
