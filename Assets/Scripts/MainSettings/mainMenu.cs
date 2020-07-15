using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour 
{
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }    
}