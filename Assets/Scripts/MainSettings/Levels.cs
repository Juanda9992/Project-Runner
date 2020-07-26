using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    #region PublicStuff
    #endregion

    #region PrivateStuff
    private static GameObject _main;

    #endregion

    #region  Singleton
    private void Start() //Hace este objeto un Singleton al recargar o cambiar entre escenas
    {
        if(_main == null)
        {
            _main = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }   
        else
        {
            Destroy(this);
        }
    #endregion


    }
    public void Restart() //Este metodo Rainicia la escena
    {
        audioPlayer.PlaySound("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Carga escena actual
        DontDestroyOnLoad(gameObject);

        GetComponent <DificultSetter>().ResetStats();
        GetComponent<cameraController>().FInd();
        Time.timeScale = 0f;
        
    }
    #region Methods
    #endregion
}
