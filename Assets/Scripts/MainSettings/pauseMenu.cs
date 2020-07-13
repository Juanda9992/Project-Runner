using UnityEngine;

public class pauseMenu : MonoBehaviour 
{
    public static bool pause = false;

    public GameObject pauseObject;

    private void Update() //Se espera que el jugador presione Esc para poner pausa, si ya esta en pausa, de despausara
    {
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
}