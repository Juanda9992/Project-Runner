using UnityEngine;

public class moveBlock : MonoBehaviour 
{
    public float speed;

    bool active = false;

    public Rigidbody2D rb;

    private void Update() 
    {

        if(active)
        {
            rb.velocity = transform.up * speed;
        }     
    }
    private void OnCollisionEnter2D(Collision2D other)  
    {
        if(other.transform.CompareTag("Player"))
        {
            active = true;
            Destroy(gameObject,4);
        }

    }    
}