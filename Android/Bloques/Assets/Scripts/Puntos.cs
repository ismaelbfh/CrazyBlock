using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour {

    public static int puntos = 0;
    public Text textoPuntos;

    public GameObject nivelCompletado;
    public GameObject juegoCompletado;

    public SiguienteNivel siguienteNivel;

    public Pelota pelota;
    public Barra barra;

    public Transform contenedorBloques;

    public SonidosFinPartida sonidosFinPartida;

    public Vidas vidas;

    // Use this for initialization
    void Start () {
        ActualizarMarcadorPuntos();
    }
	
    //metodo que se ejecutará cuando se rompe un bloque
    public void GanarPunto()
    {
        puntos = puntos + 2; //lo he puesto de 2 en 2 porque me parecía mas elegante
        ActualizarMarcadorPuntos();

        //si ya no contiene ningun hijo el objeto Bloques significará que has ganado
        if(contenedorBloques.childCount <= 0)
        {
            pelota.DetenerMovimiento(); //detendremos el movimiento
            barra.enabled = false; //deshabilitamos la barra para que ya no se pueda mover

            if (siguienteNivel.EsUltimoNivel())
            {
                juegoCompletado.SetActive(true); //si es el ultimo nivel activará el mensaje de juego completado
            }
            else
            {
                nivelCompletado.SetActive(true); // sino activará el de nivel completado
            }

            sonidosFinPartida.NivelCompletado(); //el sonido de cuando acaba el nivel
            siguienteNivel.ActivarCarga(); //invocar al siguiente nivel preestablecido por la variable publica
        }
    }

    void ActualizarMarcadorPuntos()
    {
        textoPuntos.text = "Puntos: " + puntos;
    }
}