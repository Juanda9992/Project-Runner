using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour 
{
    public static bool pause = false;
    public static bool gameStarted = false;

    public GameObject panel;

    public GameObject pauseObject;

    private void Update() //Se espera que el jugador presione Esc para poner pausa, si ya esta en pausa, de despausara
    {
        if(!gameStarted)//Si el juego no ha iniciado
        {
            if(Input.anyKeyDown)//Y se presiona una tecla cualquiera
            {
                StartGame();
                panel.SetActive(false); //Se inicia el juego y se desactiva el panel de muerte
            }
            else
            {
                Time.timeScale = 0f;//Hasta que no se pulse un boton, el juego se congela
            }

        }         
        if(Input.GetKeyDown(KeyCode.Escape)) //Si se pulsa la tecla Esc, se pausa el juego
        {
            if(pause)
            {
                Resume(); //Este metodo poneel juego otra vez en marcha
            }

            else if(!pause)
            {
                Pause(); //Si no esta pausado, se pausara
            }
        }    
    }    

    public void Resume()//Quita el modo pausa y se reestablece el juego
    {
        pauseObject.SetActive(false);
        Time.timeScale = 1f; //El tiempo vuelve a la normalidad
        pause = false;

    }

    public void Pause()
    {
        pauseObject.SetActive(true);
        Time.timeScale = 0f; //Se congela el tiempo
        pause = true;
    }

    public void Quit()//Cierra la aplicacion
    {
        Application.Quit();
    }
    public void mainMenu()//LLeva el jugador al menu principal
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void StartGame()//Cuando se oprima una tecla, el juego comienza
    {
        Time.timeScale = 1f;
        gameStarted = true;
    }

    private void OnEnable() //Cuando se reinicia la escena, se activa el panel de inicio
    {
        gameStarted = false;    
    }

}