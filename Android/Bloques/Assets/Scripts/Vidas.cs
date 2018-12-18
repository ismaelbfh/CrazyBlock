using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour {

    public static int vidas = 10;

    public Text textoVidas;

    //para invocar metodos de la pelota y barra
    public Pelota pelota;
    public Barra barra;

    public GameObject gameOver;
    public SiguienteNivel siguienteNivel;

    public SonidosFinPartida sonidosFinPartida;

	// Use this for initialization
	void Start () {
        ActualizarMarcadorVidas();
    }
	
    /// <summary>
    /// Si pierde una vida decrementando el contador de vidas, si gana o si pierde una partida que sonidos establecemos y que metodos ejecutamos cuando perdemos o ganamos
    /// </summary>
	public void PerderVida()
    {
        
        vidas--;
        ActualizarMarcadorVidas();

        if(vidas <= 0)
        {
            //suena el sonido de gameover
            sonidosFinPartida.GameOver();
            // Mostraremos GameOver
            gameOver.SetActive(true);
            pelota.DetenerMovimiento();
            barra.enabled = false;
            //cargamos siguiente nivel
            siguienteNivel.nivelACargar = "Portada";
            siguienteNivel.ActivarCarga();
        }
        else
        {
            barra.Reset();
            pelota.Reset();
        }
    }

    /// <summary>
    /// Actualiza el Text del marcador de vidas
    /// </summary>
    void ActualizarMarcadorVidas()
    {
        textoVidas.text = "Vidas: " + vidas;
    }
}
