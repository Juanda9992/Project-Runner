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
        if(!gameStarted)
        {
            if(Input.anyKeyDown)
            {
                StartGame();
                panel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
            }

        }
                
        if(Input.GetKeyDown(KeyCode.Escape))
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

    public void Resume()
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

    public void Quit()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        gameStarted = true;
    }

    private void OnEnable() 
    {
        gameStarted = false;    
    }
}