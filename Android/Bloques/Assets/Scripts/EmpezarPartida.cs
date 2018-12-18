using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EmpezarPartida : MonoBehaviour {

    public ElementoInteractivo pantalla;

	// Update is called once per frame
	void Update () {
        //Para empezar la partida tambien usaremos la barra espaciadora del teclado
	    if(Input.GetButtonDown("Fire1") || pantalla.pulsado)
        {
            //le pongo inicialmente 5 vidas [Esto se puede cambiar o puede variar en función del nivel]**Futura implementacion
            Vidas.vidas = 10;
            Puntos.puntos = 0;
            //Application.LoadLevel("Nivel01") --> no es compatible a partir de la versión de unity 5.3 [Cambiar si utilizaramos otra version mas vieja]
            SceneManager.LoadScene("Nivel01");
        }
	}
}
