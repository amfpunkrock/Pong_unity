using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed =6;
    
    public Rigidbody2D rb;
    private Vector2 startPos;
    void Start()
    {
        transform.position = startPos;
        Launch();
        
    }
    public void Reset()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
        Launch(); // se llama de nuevo a este metodo para que se lanze de nuevo la bola

    }

    public void Launch() // este metodo se encarga de lanzar la bola a izquierda o derecha
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(speed * x, speed * y); //aqui la bola va para cualquier sitio
    }


    public AudioSource hitSound; // arrastra el AudioSource de la pelota aquí en el inspector

    void OnCollisionEnter2D(Collision2D collision)  //"OnCollisionEnter2D" Unity ejecuta automáticamente cuando el objeto con este script choca con otro objeto 2D que tiene un Collider2D.
                                                    //collision contiene información del choque
    {
        // Si golpea a Player1 o Player2
        if (collision.gameObject.CompareTag("Player")) // Verifica si la pelota (Ball) chocó con un objeto que tenga el tag "Player", y si es así, reproduce el sonido de golpe.


        {
            hitSound.Play();
        }
    }
}
