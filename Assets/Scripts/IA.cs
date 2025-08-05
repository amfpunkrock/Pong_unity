using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public float speed = 4; //este es para la velocidad de la bola
    public GameObject ball;
    private Vector2 ballPos; //posicion de la bola que si va arriba o abajo
   
    void Update()
    {
        move();   //llama a este metodo y repite varias veces 
    }
    void move()
    {
        ballPos = ball.transform.position; //posicion de la bola

         if (transform.position.y > ballPos.y) //posiccion de la IA es mayor a la posicion de la bola
        {
            transform.position += new Vector3(0,-speed*Time.deltaTime);  //la velocidad de la IA baja
        }
        if (transform.position.y < ballPos.y) //posicion de la IA es menor a la posicion de la bola
        {
            transform.position += new Vector3(0,speed*Time.deltaTime, 0);  // la velocidad de la IA sube
        }


    }
    
}
