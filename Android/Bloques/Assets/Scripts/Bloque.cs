using UnityEngine;
using System.Collections;

public class Bloque : MonoBehaviour {

    //TODO ESTE SCRIPT NO SE UTILIZA PERO LO VOY A DEJAR PARA FUTURAS IMPLEMENTACIONES MIAS CUANDO TENGA TIEMPO PARA AÑADIRLE UNA FUNCIONALIDAD A LOS BLOQUES

    public GameObject efectoParticulas;

    public Puntos puntos;

    // Is Trigger DESACTIVADO (cuando choca contra ese objeto) //USAMOS ESTE
    void OnCollisionEnter()
    {
        //Instantiate(efectoParticulas, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        //transform.SetParent(null);
        //puntos.GanarPunto();
    }

    //Is Trigger ACTIVADO (cuando atraviesa ese objeto) [No se usa por ahora]
    //void OnTriggerEnter()
    //{
    //    Debug.Log("TriggerEnter");
    //}
    
}
