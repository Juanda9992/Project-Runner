using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float moveSpeed;
    [Range(380f,400f)] [Header("Altitud del salto")] public float jumpSpeed;

    private Rigidbody2D rb;
    private float xAxis;
    [HideInInspector] public bool jump;

    public LayerMask ground;
    public Transform groundPos;

    public float circleRadius;
    [HideInInspector] public int score;

    private bool inWall; 

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody para hacer el salto     

    }    
    private void FixedUpdate()
    {
        xAxis = Input.GetAxis("Horizontal");
        jump = Physics2D.OverlapCircle(groundPos.position,circleRadius,ground);

        if(xAxis > 0)
        {
            MoveRight();
        }

        //Mueve hacia la izquierda al pulsar el eje X en negativo
        if(xAxis < 0)
        {
            MoveLeft();
        }
        //Mueve hacia la derecha al pulsar el eje X en positivo

        if(xAxis == 0)
        {
            rb.velocity = new Vector2(-1 * 2, rb.velocity.y);
        }
        //Si se oprime el eje vertical positivo, el personaje saltará
        if(Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            Jump();
        }    
        if(Input.GetKey(KeyCode.Space) || xAxis > 0)
        {
            RayCasting();
        }
        
        if(rb.velocity.y > 1 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, -10);
        }
        Debug.LogWarning(jump);
        

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
        if(other.transform.CompareTag("Render"))
        {
            Death();
        }    
    }

    public void Death() //De momento solo destruye el jugador
    {   GameObject main = GameObject.FindGameObjectWithTag("Main");
        main.GetComponent<Levels>().Restart();
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(xAxis * moveSpeed,rb.velocity.y);
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(xAxis * moveSpeed,rb.velocity.y);
    }

    public void setScore(int newScore) //Esta funcion suma el puntaje del bloque tocado al puntaje del jugador
    {
        score += newScore;
        Debug.Log("Has chocado con algo y el puntaje es de  " + score.ToString());
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,jumpSpeed * Time.deltaTime);
    }
    private void RayCasting()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position,transform.right,0.5f,ground);
        Debug.DrawRay(transform.position,transform.right * 0.5f,Color.red,1f);
        if(ray)
        {
            if(!ray.collider.CompareTag("Block") || !ray.collider.CompareTag("Item") && ray.collider.CompareTag("Destructible") )
            {
                Debug.Log(ray.collider.name);
                float newSpeed = ray.collider.GetComponentInParent<newMovement>().speed;
                rb.velocity = new Vector2((newSpeed + 0.1f / 2) * -1,rb.velocity.y);
            }

        }
    }

    
}