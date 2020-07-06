using UnityEngine;

public class movement : MonoBehaviour 
{
    public float blockSpeed; //La velocidad de los bloques
    public int points;
    public bool active;

    private void Start() //Se destruira el objeto en 15 segundos para no sobrecargar la memoria
    {
        this.active = false;
        Destroy(gameObject,15);
    }
    private void FixedUpdate()
    {
        //Mueve el bloque constantemente hacia la izquierda
        transform.Translate(Vector2.left * blockSpeed * Time.deltaTime);
    }    

    private void OnCollisionEnter2D(Collision2D other) //Si el bloque no ha sido tocado anteriormente, se le dara puntaje al jugador
    {
        if(other.transform.CompareTag("Player") && this.active == false)
        {
            other.gameObject.GetComponent<PlayerController>().setScore(this.points);
            active = true;
        }    
    }

}