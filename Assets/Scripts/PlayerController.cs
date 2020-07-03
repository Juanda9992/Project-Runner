using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float moveSpeed;
    [Range(380f,400f)] [Header("Altitud del salto")] public float jumpSpeed;

    private Rigidbody2D rb;
    private bool jump;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody para hacer el salto    
    }    
    private void FixedUpdate()
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
        //Si se oprime el eje vertical positivo, el personaje saltará
        if(Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed * Time.deltaTime);
        }
        if(rb.velocity.y > 0.2 && !Input.GetKey(KeyCode.Space) && jump == false) //Si no se oprime la tecla de salto mientras esta en el aiere, el personaje caera mas rapido
        {
            rb.velocity = new Vector2(rb.velocity.x,-8);
        }

        Mathf.Clamp(rb.velocity.y,-20,10);//Limita la velocidad en y para evitar bugs de fisicas
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Si colisiona con un bloque el jugador muere
        if(other.transform.CompareTag("NoLethal") || other.transform.name == "Ground")
        {
            jump = true;
            float newSpeed = other.gameObject.GetComponent<movement>().blockSpeed;
            rb.velocity = new Vector2(-newSpeed,rb.velocity.y);
        }

        if(other.transform.CompareTag("Block"))
        {
            Death();
        }
           

    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.transform.CompareTag("NoLethal"))
        {
            jump = false;
        }    
    }

    public void Death() //De momento solo destruye el jugador
    {
        Destroy(this.gameObject);
    }
}