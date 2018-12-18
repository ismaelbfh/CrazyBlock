using UnityEngine;

public class Suelo : MonoBehaviour {

    public Vidas vidas;

    public SonidosFinPartida sonidosFinPartida;

    //Cuando toque el suelo que suene el sonido del suelo y pierda una vida
    void OnTriggerEnter()
    {
        sonidosFinPartida.SonidoSuelo();
        vidas.PerderVida();
    }

}
