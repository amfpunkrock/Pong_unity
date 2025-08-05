using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.RuleTile.TilingRuleOutput;



public class Players : MonoBehaviour
{
    public bool player1;
    public float speed = 3;
    public Rigidbody2D rb;

    private float move;
    private Vector2 startPos;

    private float moveSpeedTouchControl = 0.2f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        move = 0; // Reiniciamos el movimiento cada frame,para evitar que el jugador se siga moviendo cuando no se presiona ninguna tecla 

        // --- CONTROL POR TECLADO (para pruebas en PC) :
        if (player1)
            move = Input.GetAxisRaw("Vertical");  // Detecta flechas (arriba o abajo) o W/S
        else
            move = Input.GetAxisRaw("Vertical2"); // Detecta flechas (arriba o abajo)  o W/S

        // --- CONTROL POR PANTALLA TÁCTIL DEL MOVIL:
        if (Input.touchCount > 0) // Input.touchount significa cuántos dedos están tocando la pantalla en ese momento, y sera aunque sea mas de 1 solo toque
        {
            for (int i = 0; i < Input.touchCount; i++) // for recorre todos los dedos en pantalla, es neesario "for" para detetar a dos jugadores"players" al mismo tiempo
            {
                Touch touch = Input.GetTouch(i); //Input.GetTouch(i) obtiene la información del toque número i
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position); //touch.position te da la posición en pixeles de pantalla donde está tocando el dedo
                                                                                   // "Camera" busca la camara princcipal de la escena y con el Vector3 comporobamos si va arriba o abajo o otro lado
                                                                                   // ScreentoWorldPoint es para detectar la posiion del "touch"o del toque

                // Para "player1" (izquierda):
                if (player1 && touch.position.x < Screen.width / 2) // "touch.position.x < Screen.width / 2": verifica si el toque ocurrió en la mitad izquierda de la pantalla.
                                                                    //"Screen.width" es el ancho total de la pantalla en píxeles y "Screen.width / 2" es la mitad.
                {
                    if (touchPos.y > transform.position.y + 0.2f)   //touchPos.y es la posición vertical del dedo en el mundo (ya convertida con Camera.main.ScreenToWorldPoint).//
                                                                    //"transform.position.y" es la posición vertical actual del jugador. si esta mas de 2 unidades el player sube
                        transform.Translate(0, moveSpeedTouchControl, 0); // sube con "transform.Translate" en sentido vertical 
                    else if (touchPos.y < transform.position.y - 0.2f)  // si el dedo esta -2 unidades va para abajo en sentido vertical
                        transform.Translate(0, -moveSpeedTouchControl, 0);  // aqui baja con "transform.Translate" en sentido vertical
                }

                // Para Player 2 (derecha)
                else if (!player1 && touch.position.x > Screen.width / 2) //!player1: El signo ! significa "NO". Así que esta condición se cumple si el script NO está controlando al Player 1, es decir, está controlando al Player 2(derecha).
                                                                          // "touch.position.x > Screen.width / 2" verifica que el dedo esta toando la mitad derecha de la pantalla
                {
                    if (touchPos.y > transform.position.y + 0.2f)     // Si el dedo está por encima del player → mueve hacia arriba.
                        transform.Translate(0, moveSpeedTouchControl, 0);
                    else if (touchPos.y < transform.position.y - 0.2f)   // Si el dedo está por debajo del player → mueve hacia abajo.
                        transform.Translate(0, -moveSpeedTouchControl, 0);
                }
            }
        }

        
        rb.velocity = new Vector2(rb.velocity.x, move * speed); //"rb.velocity" es la velocidad actual del Rigidbody2D (el componenete fisico del jugador o player
                                                                //aqui se crea un nuevo vector de velocidad "new Vector2", aqui se mantiene la velocidad horizontal 
                                                                //move * speed: calculamos la velocidad vertical multiplicando la dirección vertical (move) por la rapidez (speed).
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;   //Vector2.zero es lo mismo que (0,0)
        transform.position = startPos;  //Con esta línea, la paleta vuelve exactamente a la posición donde estaba cuando empezó el juego.
    }
}
