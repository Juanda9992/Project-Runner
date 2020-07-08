using UnityEngine;

public class movement : MonoBehaviour 
{
    [SerializeField] public float blockSpeed; //La velocidad de los bloques
    public int points;
    public bool active;
    int time;

    private void Start() //Se destruira el objeto en 15 segundos para no sobrecargar la memoria
    {
        this.active = false;
        time = GetComponentInParent<Optimization>().destructionTime;
        Destroy(gameObject,time);

        blockSpeed = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().currentSpeed; //Obtiene la velocidad del script del objeto Main
        InvokeRepeating("LookForSpeed",1,3);//Cada 5 segundos actualizara la velocidad
    }
    private void Update()
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

    private void LookForSpeed()
    {
        blockSpeed = GameObject.FindGameObjectWithTag("Main").GetComponent<DificultSetter>().currentSpeed; //Actualiza la velocidad para estar a la misma velocidad de los otros bloques
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.CompareTag("Render"))
        {
            Debug.Log("Adios");
            Destroy(gameObject);
        }    
    }

}