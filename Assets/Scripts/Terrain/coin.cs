using UnityEngine;

public class coin : MonoBehaviour 
{
    public int score; //Puntaje
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Moneda Recogida");
        if(other.transform.CompareTag("Player")) //Si toca al jugador, s destruye el objeto y suma el puntaje 
        {
            other.gameObject.GetComponent<PlayerController>().setScore(this.score);
            Destroy(this.gameObject);
        }    
    }    
}