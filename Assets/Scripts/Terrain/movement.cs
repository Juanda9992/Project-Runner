using UnityEngine;

public class movement : MonoBehaviour 
{
    public int points;
    public bool active;
    int time;
    GameObject main;

    private void Start() //Se destruira el objeto en 15 segundos para no sobrecargar la memoria
    {

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