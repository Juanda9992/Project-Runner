using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float moveSpeed;
    [Range(380f,400f)] [Header("Altitud del salto")] public float jumpSpeed;

    private Rigidbody2D rb;
    private bool jump;
    [SerializeField] public int score;

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
            Debug.Log("HAs saltado");
        }
        if(rb.velocity.y > 0.2 && !Input.GetKey(KeyCode.Space) && jump == false) //Si no se oprime la tecla de salto mientras esta en el aiere, el personaje caera mas rapido
        {
            rb.velocity = new Vector2(rb.velocity.x,-8);
        }

        Mathf.Clamp(rb.velocity.y,-20,10);//Limita la velocidad en y para evitar bugs de fisicas
        
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.3f,transform.position.y),-transform.up,0.8f,1 << 8);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.3f,transform.position.y),-transform.up,0.8f,1 << 8);
        Debug.DrawRay(new Vector2(transform.position.x - 0.3f,transform.position.y),Vector2.down * 0.8f,Color.red,1);

        if(hitLeft || hitRight) //Si el rayo golpea, es porque esta encima de algo y podra saltar
        {
            if(hitRight)
            {
                jump = true;                
            }
            else if(hitLeft)
            {
                jump = true;       
            }
            
        }
        if(!hitRight && !hitLeft && !Input.GetKey(KeyCode.Space)) //Si no esta debajo de algo, aumentara su gravedad
        {
            rb.gravityScale = 3;

        }
        else
        {
            rb.gravityScale = 0.9f; //De lo contrario, seguira normal
        }
        if(!hitLeft && !hitRight)
        {
            jump = false; //Si no golpea nada, no podra saltar
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        

        //Si colisiona con un bloque letal el jugador muere
        if(other.transform.CompareTag("Block"))
        {
            Death();
        }
    }
    private void OnCollisionStay2D(Collision2D other) //Se cambia la velocidad a ña del bloque con el que colisiona
    {
        float newSpeed = other.gameObject.GetComponentInParent<newMovement>().speed;
        rb.velocity = new Vector2(-newSpeed,rb.velocity.y);
        Debug.Log("Tu velocidad es de: " + rb.velocity.x);
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.transform.CompareTag("Render"))
        {
            
            Death();

        }    
    }

    public void Death() //De momento solo destruye el jugador
    {   GameObject main = GameObject.FindGameObjectWithTag("Main");
        main.GetComponent<Levels>().Restart();    
    }

    public void setScore(int newScore) //Esta funcion suma el puntaje del bloque tocado al puntaje del jugador
    {
        score += newScore;
        Debug.Log("Has chocado con algo y el puntaje es de  " + score.ToString());
    }
}