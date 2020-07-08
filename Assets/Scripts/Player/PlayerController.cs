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
        }
        if(rb.velocity.y > 0.2 && !Input.GetKey(KeyCode.Space) && jump == false) //Si no se oprime la tecla de salto mientras esta en el aiere, el personaje caera mas rapido
        {
            rb.velocity = new Vector2(rb.velocity.x,-8);
        }

        Mathf.Clamp(rb.velocity.y,-20,10);//Limita la velocidad en y para evitar bugs de fisicas
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position,-transform.up,0.8f,1 << 8); //RayCast para detectar colisiones
        Debug.DrawRay(transform.position,-transform.up * 0.8f,Color.red,1f);
        Debug.Log(jump);
        if(hit)
        {
            jump = true;
        }
        if(!hit && !Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = 3;

        }
        else
        {
            rb.gravityScale = 0.9f;
        }
        if(!hit)
        {
            jump = false;
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
        float newSpeed = other.gameObject.GetComponent<movement>().blockSpeed + 0.5f;
        rb.velocity = new Vector2(-newSpeed,rb.velocity.y);
    }

    public void Death() //De momento solo destruye el jugador
    {
        Destroy(this.gameObject);
    }

    public void setScore(int newScore) //Esta funcion suma el puntaje del bloque tocado al puntaje del jugador
    {
        score += newScore;
        Debug.Log("Has chocado con algo y el puntaje es de  " + score.ToString());
    }
}