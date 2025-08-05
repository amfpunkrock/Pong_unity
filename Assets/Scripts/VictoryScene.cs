using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainMenu",3);   // invoca al metodo y que se demora en cargar 3 segundos
    }
    public void LoadMainMenu() //cargar el menu principal
    {
        SceneManager.LoadScene("MainMenu"); //envia a la escena del menu principal
    }

}

    
