using UnityEngine;

public class movement : MonoBehaviour 
{
    public float blockSpeed; //La velocidad de los bloques


    private void FixedUpdate()
    {
        //Mueve el bloque constantemente hacia la izquierda
        transform.Translate(Vector2.left * blockSpeed * Time.deltaTime);
    }    

}