using UnityEngine;

public class movement : MonoBehaviour 
{
    public float blockSpeed; //La velocidad de los bloques


    private void Update()
    {
        //Mueve el bloque constantemente hacia la izquierda
        transform.Translate(Vector2.left * blockSpeed * Time.deltaTime);
    }    

}