using UnityEngine;
using System.Collections;

public class DificultSetter : MonoBehaviour
{

    #region PublicStuff
    public float speedChange; //La velocidad que va a cambiar
    public float delayTime; //Cada cuanto va a cambiar

    public float currentSpeed;
    public float maxTime;
    #endregion

    #region PrivateStuff

    float currentTime;
    #endregion

    [HideInInspector] public float initialTime;
    [HideInInspector] public float initialSpeed;

    private void Start() 
    {
        initialSpeed = currentSpeed;
        initialTime = maxTime;    
    }
    void Update() //Este metodo actua como cronometro, al llegar a cero la dificutad aumenta
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            SetDificult();
            currentTime = delayTime;
        }
    }

    #region Methods

    public void SetDificult() //Esye metodo aumenta la dificultas aumentando la velocidad de los bloques y disminuyendo el radio de spawneo
    {
        currentSpeed += speedChange;
        maxTime -= 0.05f;
    }

    public void ResetStats()
    {
        currentSpeed = initialSpeed;

        maxTime = initialTime;
    }
    #endregion
}
