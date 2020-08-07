using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    #region PublicStuff
    public GameObject deathPanel;
    #endregion

    #region PrivateStuff
    private static GameObject _main;

    public AudioSource audioSource;

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

    public IEnumerator playerRestart(int Timedelay)
    {
        audioSource.pitch = 0.6f;
        Time.timeScale = 0.5f;
        deathPanel.GetComponent<Animator>().SetBool("PlayerDeath", true);
        yield return new WaitForSeconds(Timedelay);
        audioSource.Stop();
        Restart();
    }
    public void Restart() //Este metodo Rainicia la escena
    {
        audioPlayer.PlaySound("death");
        deathPanel.GetComponent<Animator>().SetBool("PlayerDeath", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Carga escena actual
        DontDestroyOnLoad(gameObject);
        

        GetComponent <DificultSetter>().ResetStats();
        GetComponent<cameraController>().FInd();
        Time.timeScale = 0f;
        
    }
    #region Methods
    #endregion
}
