using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pelota : MonoBehaviour {

    public float velocidadInicial = 600f;
    bool enJuego = false;

    Rigidbody rig;

    Vector3 posicionInicial;

    Transform barra;
    
    public GameObject efectoParticulas;

    public Puntos puntos;

    public Material materialCambioBloque;

    private List<string> listaBloquesGolpeados = new List<string>();

    public ElementoInteractivo pantalla;

    //se hace antes de START
    void Awake()
    {
        //le decimos que el rigibody sea el propio y guardamos el transform de la barra (su padre)
        rig = GetComponent<Rigidbody>();
        barra = transform.parent;
        
    }

	// Use this for initialization
	void Start ()
    {
        posicionInicial = transform.position;
    }

    //resetea la pelota a su posicion inicial indicandole que es hijo de barra para que vayan juntas al moverlo
    public void Reset()
    {
        transform.position = posicionInicial;
        transform.SetParent(barra);
        enJuego = false; //variable boleana para controlar si se le pulsa al botón para empezar el juego, si es falso es que va a estar quieta
        DetenerMovimiento();
    }

    public void DetenerMovimiento()
    {
        //la deja en su posicion inicial
        rig.isKinematic = true;
        rig.velocity = Vector3.zero;
    }

    // TODO: en vez de hacer un script de colisiones en cada bloque lo hacemos a nivel generico que nos servirá para futuras implementaciones de niveles
    void OnCollisionEnter(Collision otroObjeto)
    {
        if (otroObjeto.gameObject.CompareTag("Bloque"))
        {
            Instantiate(efectoParticulas, transform.position, Quaternion.identity);
            Destroy(otroObjeto.gameObject);
            otroObjeto.gameObject.transform.SetParent(null);
            puntos.GanarPunto();
        }
        else if (otroObjeto.gameObject.CompareTag("BloquesEspeciales"))
        {
            //Si ese nombre de bloque golpeado no esta contenido en la lista significará que es la primera vez que le golpea y porn tanto no se destruye solamente cambia la textura del material para que parezca como roto
            if (!listaBloquesGolpeados.Contains(otroObjeto.gameObject.name))
            {
                listaBloquesGolpeados.Add(otroObjeto.gameObject.name); //y por supuesto se añade a la lista para que la proxima vez si que se destruya
                //le pone otro material distinto (como de bloque roto):
                var mat = otroObjeto.gameObject.GetComponent<Renderer>().materials;
                mat[0] = materialCambioBloque;
                otroObjeto.gameObject.GetComponent<Renderer>().materials = mat;
            }
            else
            {
                //el efecto de las particulas cayendo y desvaneciendose
                Instantiate(efectoParticulas, transform.position, Quaternion.identity);
                Destroy(otroObjeto.gameObject);
                otroObjeto.gameObject.transform.SetParent(null);
                //y ganara x puntos segun lo establecido en la funcion "GanarPunto", yo le he puesto que de 2 en 2 [se puede cambiar]
                puntos.GanarPunto();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //TODO : Fire1 está configurado como que el control para iniciar partida sea la barra espaciadora del teclado, pero esta configuracion se puede cambiar en "Edit > Project Settings > Input" pulsando en Fire1, donde pone "positive button"
        //si está quieta la pelota y la barra y se pulsa la barra espaciadora del teclado.
        //Añado tactil si pulsa la pantalla que se lance la pelota
        if (!enJuego && (Input.GetButtonDown("Fire1") || pantalla.pulsado))
        {
            enJuego = true;
            transform.SetParent(null); //la pelota dejará de tener el padre barra y irá independiente del movimiento de la barra
            rig.isKinematic = false; //para que no esté en estatica
            rig.AddForce(new Vector3(velocidadInicial, velocidadInicial, 0)); //añadirle una fuerza en los ejes "x" e "y" de 600(variable publica inicializada ^^), el eje "z" nos da igual
        }
	}
}
