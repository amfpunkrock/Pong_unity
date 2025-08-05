using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    public GameObject player1;
    public GameObject player1Goal;

    public GameObject player2;
    public GameObject player2Goal;

    public Text player1Text;
    public Text player2Text;

    private int player1Score; //puntuacion de jugasdor1
    private int player2Score; //puntuacion de jugasdor2

    public bool IAGame;

    public int maxScore = 3; // cuando consigamos 3 puntos igual o mayor es que ha ganado o salido en victoria

    public void CheckVictory()
    {
        if (player1Score >= 3)
        {
            SceneManager.LoadScene("VictoryPlayer1"); // cuando gana el player1 sale esta escena"VictoryPlayer1"
        }
        if (player2Score >= 3)
        {
            SceneManager.LoadScene("VictoryPlayer2"); // cuando gana el player2 sale esta escena"VictoryPlayer2"
        }
    
    }

    public void Player1Scored()
    {
        player1Score++;
        player1Text.text = player1Score.ToString();
        CheckVictory();  // llamar a este metodo CheckVictory para que salga la ccomprobacion sobre el puntaje(Scored)
        ResetPosition();
    }
    public void Player2Scored()
    {
        player2Score++;
        player2Text.text = player2Score.ToString();
        CheckVictory();  // llamar a este metodo CheckVictory para que salga la ccomprobacion sobre el puntaje(Scored)
        ResetPosition();
    }
    public void ResetPosition()
    {
        if (IAGame)
        {
            ball.GetComponent<Ball>().Reset(); //Reset llama al metdo que esta dentro del script <Ball>
            player1.GetComponent<Players>().Reset(); // este llama al metodo RESET de player1
        }
        else
        {
            ball.GetComponent<Ball>().Reset(); //Reset llama al metodo que esta dentro del script <Ball>
            player1.GetComponent<Players>().Reset(); // este llama al metodo RESET de player1
            player2.GetComponent<Players>().Reset(); // este llama al metodo Reset del player2
        }
           
    }





}
