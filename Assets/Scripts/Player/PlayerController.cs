using UnityEngine;

public class PlayerController : MonoBehaviour 
{

    #region  Components&Variables
    [Header("Velocidad de movimiento")] public float moveSpeed;
    [Range(500,650)] [Header("Altitud del salto")] public float jumpSpeed;

    private Rigidbody2D rb;
    private float xAxis;

    [HideInInspector] public int score;

    float worldSpeed;

    public GameObject main;
    public GameObject particle;
    bool lookRight = true;

    private Animator animator;
    #endregion

    #region UnityMethods
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody para hacer el salto  
        animator = GetComponent<Animator>();   

    }    
    private void FixedUpdate()
    {
        xAxis = Input.GetAxis("Horizontal");

        if(xAxis > 0) //Si el eje X es mayor a 0, el personaje se movera
        {
            MoveRight();
            animator.SetBool("walking", true);
    
        }

        //Mueve hacia la izquierda al pulsar el eje X en negativo
        if(xAxis < 0)
        {
            animator.SetBool("walking", true);
            MoveLeft();
            
        }
        //Mueve hacia la derecha al pulsar el eje X en positivo

        if(xAxis == 0)
        {
            animator.SetBool("walking", false);
            worldSpeed = main.GetComponent<DificultSetter>().currentSpeed;
            rb.velocity = new Vector2(-worldSpeed - 0.01f, rb.velocity.y); //Si esta quieto, el personaje se movera a la misma velocidad que el mundo
        }
        //Si se oprime el eje vertical positivo, el personaje saltará
 
        
        if(rb.velocity.y > 1 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, -5); //Si esta en el aire, no se oprime la tecla espacio y no puede saltar, caera mas rapido
        }
        if(lookRight == false && xAxis > 0)
        {
            Flip();
        }
        else if(lookRight == true && xAxis < 0)
        {
            Flip();
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

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.transform.CompareTag("Render")) //Si se sale de la zona segura el personaje morira
        {
            Death();
        }    
    }
    #endregion

    #region  Methods

    public void Death() //De momento solo destruye el jugador
    {   
        GameObject main = GameObject.FindGameObjectWithTag("Main");
        audioPlayer.PlaySound("death");
        StartCoroutine(main.GetComponent<Levels>().playerRestart(2));
        transform.position = transform.right * 100f;
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(xAxis * moveSpeed,rb.velocity.y); //Mueve hacia la derecha
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(xAxis * moveSpeed * 1.2f,rb.velocity.y); //Mueve hacia la izquierda
    }

    public void setScore(int newScore) //Esta funcion suma el puntaje del bloque tocado al puntaje del jugador
    {
        score += newScore;
        Debug.Log("Has chocado con algo y el puntaje es de  " + score.ToString());
    }

    public void Jump()
    {
        rb.velocity = new Vector2 (rb.velocity.x,jumpSpeed * Time.fixedDeltaTime);
    }

    public void Flip()
    {
        lookRight = !lookRight;
        transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
    }


    #endregion
}