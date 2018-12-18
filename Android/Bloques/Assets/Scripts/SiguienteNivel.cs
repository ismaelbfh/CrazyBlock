using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour {

    public string nivelACargar;
    public float retraso;

    //Lo del context se pone para que en tiempo de ejecucion cuando programamos lo podamos ver en el editor de Unity, sin esto no ocurriría, al ejecutable le da lo mismo
    [ContextMenu("ActivarCarga")]
    public void ActivarCarga()
    {
        Invoke("CargarNivel", retraso);
    }

    /// <summary>
    /// Carga un nivel en funcion a la variable publica "nivelACargar"
    /// </summary>
    void CargarNivel()
    {
        //si no es el ultimo nivel ponle una vida
        if (!EsUltimoNivel())
        {
            Vidas.vidas= Vidas.vidas + 5;
        }
        //carga el siguiente nivel
        SceneManager.LoadScene(nivelACargar);
    }

    /// <summary>
    /// Devuelve true si es la portada y false si es otro nivel distinto a cargar (lo que le hayamos puesto a la variable publica "nivelACargar" en cada nivel, el último nivel tendra en esta variable la palabra "Portada" para que cargue la escena de la portada).
    /// </summary>
    /// <returns></returns>
    public bool EsUltimoNivel()
    {
        return nivelACargar == "Portada";
    }
}
