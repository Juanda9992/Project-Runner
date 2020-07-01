using UnityEngine;

public class dash : MonoBehaviour 
{
    public float dashTime;
    private string direction = "Right";
    float speed = 30;
    float currentDash;

    private void Start() 
    {
        currentDash  = dashTime;   //Se establece el tiempo del Dash
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) //Si pulsa el eje horizontal negativo, mirara hacia la izquierda
        {
            direction = "Left";
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) //Si pulsa el eje horizontal positivo, mirara hacia la derecha
        {
            direction = "Right";
        }    
        if(Input.GetKeyDown(KeyCode.LeftShift)) // Al pulsar Shift el personaje Dasheara
        {
            Dash();
        }
        currentDash -= Time.deltaTime;//El tiempo del Dash disminuye con el tiempo
    }    

    private void Dash()
    {
        //Si esta mirando hacia la izquierda y el tiempo de dash se ha excedido, el Dash sera hacia la izquierda
        if(direction == "Left" && currentDash < 0)
            {
                transform.position = new Vector2(transform.position.x - 3, transform.position.y);
                currentDash = dashTime;//El Tiempo de Dash vuelve a ser el del valor inicial
            }
        //Si esta mirando hacia la Derecha y el tiempo de dash se ha excedido, el Dash sera hacia la Derecha
           if(direction == "Right" && currentDash < 0)
            {
                transform.position = new Vector2(transform.position.x + 3, transform.position.y);
                currentDash = dashTime;//El Tiempo de Dash vuelve a ser el del valor inicial
            }
    }

}