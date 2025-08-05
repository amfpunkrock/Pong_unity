using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // esta libreria se encarga del control de escenas

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // al apretar el boton Escape , sale del videojuego
        {
            Application.Quit(); //Para salir del videojuego
        }
    }



    public void PlayerVSIA()
     {
        

        SceneManager.LoadScene("PlayerVSIA");
     }
     public void PlayerVSPlayer()
    {
        SceneManager.LoadScene("PlayerVSPlayer");
    }


  


}
