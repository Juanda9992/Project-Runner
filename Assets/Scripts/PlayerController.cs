using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public int moveSpeed;

    Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody para hacer el salto    
    }    
    private void Update()
    {
        //Mueve hacia la izquierda al pulsar el eje X en negativo
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-moveSpeed * Time.deltaTime,0f));
        }
        //Mueve hacia la derecha al pulsar el eje X en positivo
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(moveSpeed * Time.deltaTime,0f));
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Si colisiona con un bloque el jugador muere
        if(other.transform.CompareTag("Block"))
        {
            Death();
        }    
    }

    public void Death() //De momento solo destruye el jugador
    {
        Destroy(this.gameObject);
    }
}