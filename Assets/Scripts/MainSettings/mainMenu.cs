using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour 
{
    public void LoadGame()//Va a la siguiente escena
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }    
    public void LoadLink(string link)
    {
        Application.OpenURL(link);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu(string menu)
    {
        SceneManager.LoadScene(menu);
    }
}