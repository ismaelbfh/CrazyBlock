using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour {

    public bool salir; //ésta variable solo se pondrá a true en la escena de Portada para que el usuario cuando le de a la tecla acordada salga de la aplicación y se cierre

	// Update is called once per frame
	void Update () {
        //Para quitar el juego se tiene que pulsar la tecla escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (salir)
            {
                Application.Quit(); //solo entrará aqui en la escena de Portada [ESTO NO SE VE EN EL MODO DE EDICIÓN EN UNITY PARA COMPROBARLO: "Debug.Log("Salió del Juego")"]
            }
            else //Sino volverá a la portada
            {
                //Application.LoadLevel("Portada") --> no es compatible a partir de la versión de unity 5.3 [Cambiar si utilizaramos otra version mas vieja]
                SceneManager.LoadScene("Portada");
            }
        }
	}
}
