using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    #region PublicStuff
    #endregion

    #region PrivateStuff
    private static GameObject _main;
    #endregion
    private void Start() 
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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(gameObject);
        
    }

    

    #region Methods
    #endregion
}
