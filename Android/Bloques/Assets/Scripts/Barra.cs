using UnityEngine;
using System.Collections;

public class Barra : MonoBehaviour {

    public float velocidad = 20.0f;

    Vector3 posicionInicial;

    public ElementoInteractivo botonIzquierda;
    public ElementoInteractivo botonDerecha;

    // Use this for initialization
    void Start ()
    {
        posicionInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float direccion = 0.0f;
        //esto lo hacemos para  si pulsa el izquierdo devolvera -1 si el botonderecho es pulsado devuelve 1 y sino devuelve que lo hacemos desde el teclado
        direccion = botonIzquierda.pulsado ? 
                        -1 : 
                            (botonDerecha.pulsado ? 
                            1 :
                                Input.GetAxisRaw("Horizontal"));

        //Calcular en una variable la posicion al mover a la derecha (por fotograma)
        float posX = transform.position.x + (direccion * velocidad * Time.deltaTime);

        //Transforma la posicion en funcion a los valores de x y y z lo del Math.Clamp es como if(posX>8)posX=8; if(posX<-8)posX=-8;
        transform.position = new Vector3(Mathf.Clamp(posX, -8, 8), transform.position.y, transform.position.z);   
    }

    public void Reset()
    {
        transform.position = posicionInicial;
    }
}
