using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Parametros de movimiento"), Space]
    [Tooltip("Velocidad de movimiento")]
    public float speed;

    //referencia al valor del input axis horizontal
    private float h;
    //referencia al valor del input axis vertical
    private float v;

    //vector de movimiento
    private Vector2 movement;

    [Header("Limites de pantalla"), Space]
    [Tooltip("LIMITE DE MOVIMIENTO EN EL EJE X")]
    public float xLimit;

    [Tooltip("LIMITE DE MOVIMIENTO EN EL EJE Y")]
    public float yLimit;

    

    //Referencias
    //Referencia al rigidbody 2d

    private Rigidbody2D rb2d;

        private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }




    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //recuperamos los valores de los axis horizontal y vertical
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        LimitMovement();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Metodo que se encargara de realizar el movimiento el jugador
    /// </summary>
    private void Movement()
    {

        
        //generamos un vector de movimiento y lo normalizamos
        movement = new Vector2(h, v).normalized;

        //Aplicamos el movimiento sobre el jugador
        rb2d.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);

        //Aplicamos los límites del movimiento en pantalla

        
    
    }

    public void LimitMovement()
    {
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector2(xLimit, transform.position.y);
        }
        else if (transform.position.x < -xLimit)
        {
            transform.position = new Vector2(-xLimit, transform.position.y);
        }

        if (transform.position.y > yLimit)
        {
            transform.position = new Vector2(transform.position.x, yLimit);
        }
        else if (transform.position.y < -yLimit)
        {
            transform.position = new Vector2(transform.position.x, -yLimit);
        }
    }





















}
