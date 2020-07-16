using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    #region PublicStuff
    #endregion

    #region PrivateStuff
    private static GameObject _main;

    #endregion
    private void Start() //Hace este objeto un Singleton
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


    }
    public void Restart() //Este metodo Rainicia la escena
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Carga escena actual
        DontDestroyOnLoad(gameObject);

        GetComponent <DificultSetter>().ResetStats();
        GetComponent<cameraController>().FInd();
        Time.timeScale = 0f;
        
    }
    #region Methods
    #endregion
}
