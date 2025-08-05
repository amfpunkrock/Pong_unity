using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool player1Goal;
    public GameObject gameManager; //creo una referencia a nuestro GameManager

    public void OnTriggerEnter2D(Collider2D collision) //es para saber que TAG tiene
    {
        if (collision.CompareTag("Ball"))
        {
            if (player1Goal)
            {
                gameManager.GetComponent<GameManager>().Player1Scored();//si es gol para el jugador 1 aumenta el Score
            }

            else
            {
                gameManager.GetComponent<GameManager>().Player2Scored(); //pero si es gol para el jugador 2 aumenta el Score
            }
        }
    }






}
